using AutoMapper;
using SistemaTurnos.Common;
using SistemaTurnos.Dal;
using SistemaTurnos.Dal.Entities;
using SistemaTurnos.Dto.Turno;
using SistemaTurnos.Helpers;
using SistemaTurnos.Service.Interface;
using System.Diagnostics;

namespace SistemaTurnos.Service
{
    public class TurnoService : ITurnoService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public TurnoService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<bool> MedicoIsAviable(TurnoCreateRequestDTO dto)
        {
            string diaSemana = dto.Fecha.DayOfWeek.ToString();

            bool diaSemanaExiste = Enum.TryParse<DayOfWeekEnum>(diaSemana, out DayOfWeekEnum result);
            int indiceDiaSemana = (int)result;

            TimeSpan tiempo = dto.Fecha.TimeOfDay;

            var medicoDisponible = await _unitOfWork.DisponibilidadMedicoRepository.MedicoIsAviable(dto.MedicoId, indiceDiaSemana, tiempo);

            return medicoDisponible.Count() > 0 ? true : false;
        }

        public async Task<TurnoResponseDTO> Create(TurnoCreateRequestDTO dto)
        {
            var medico = await _unitOfWork.MedicoRepository.GetId(dto.MedicoId);
            if (medico == null)
                throw new Exception(ErrorMessages.MedicoNotFound);

            var paciente = await _unitOfWork.PacienteRepository.GetId(dto.PacienteId);
            if (paciente == null)
                throw new Exception(ErrorMessages.PacienteNotFound);

            var medicoIsAviable = await MedicoIsAviable(dto);
            if (!medicoIsAviable)
                throw new Exception(ErrorMessages.MedicoHorarioNotAviable);

            var hayTurnosCerca = await FilterByDateTime(dto.Fecha, dto.MedicoId);
            if (hayTurnosCerca.Count > 0)
                throw new Exception(ErrorMessages.HorarioTurnoOcupado);

            var entity = _mapper.Map<Turno>(dto);
            await _unitOfWork.TurnoRepository.Add(entity);
            await _unitOfWork.Save();
            return _mapper.Map<TurnoResponseDTO>(entity);
            //throw new Exception(ErrorMessages.HorarioTurnoOcupado);
        }

        public async Task<List<TurnoResponseDTO>> FilterByDateTime(DateTime fecha, int? medicoId)
        {
            if (medicoId.HasValue)
            {
                var medico = await _unitOfWork.MedicoRepository.GetId((int)medicoId);
                if (medico == null)
                    throw new Exception(ErrorMessages.MedicoNotFound);
            }
            var turnos = await _unitOfWork.TurnoRepository.FilterByDateTime(fecha, medicoId);
            var rsta = _mapper.Map<List<TurnoResponseDTO>>(turnos);
            return rsta;
        }

        public async Task<List<TurnoResponseDTO>> FilterByDoctor(int id, EstadoTurno? estadoTurno)
        {

            var medico = await _unitOfWork.MedicoRepository.GetId(id);
            if (medico == null)
                throw new Exception(ErrorMessages.MedicoNotFound);

            var turnos = await _unitOfWork.TurnoRepository.FilterByDoctor(id);
            var rsta = _mapper.Map<List<TurnoResponseDTO>>(turnos);

            return rsta;
        }

        public Task<List<TurnoResponseDTO>> FilterByDoctorProgramedToday(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<TurnoResponseDTO>> FilterByEstadoTurno(EstadoTurno estado)
        {
            var turnos = await _unitOfWork.TurnoRepository.FilterByEstadoTurno(estado);
            var rsta = _mapper.Map<List<TurnoResponseDTO>>(turnos);

            return rsta;
        }

        public async Task<List<TurnoResponseDTO>> FilterByPaciente(int id)
        {

            var paciente = await _unitOfWork.PacienteRepository.GetId(id);
            if (paciente == null)
                throw new Exception(ErrorMessages.PacienteNotFound);

            var turnos = await _unitOfWork.TurnoRepository.FilterByPaciente(id);
            var rsta = _mapper.Map<List<TurnoResponseDTO>>(turnos);
            return rsta;
        }


        public async Task<List<TurnoResponseDTO>> GetAll()
        {
            var turnos = await _unitOfWork.TurnoRepository.GetAll();
            var rsta = _mapper.Map<List<TurnoResponseDTO>>(turnos);
            return rsta;
        }

        public bool HayTurno(TimeSpan i, TimeSpan tiempoTurno, List<Turno> turnosDia)
        {
            return turnosDia.Any(turno =>
            {
                var diferenciaDeTiempoTurnoPrevio = (turno.Fecha.TimeOfDay - i).Duration();
                var diferenciaDeTiempoTurnoProximo = (i - turno.Fecha.TimeOfDay).Duration();
                return diferenciaDeTiempoTurnoPrevio < tiempoTurno || diferenciaDeTiempoTurnoProximo < tiempoTurno;
            });

        }
        //valida con rango de 20 mins
        public bool TuroDisponible(TimeSpan i, HashSet<TimeSpan> horariosOcupados)
        {
            bool dentroDelRango = horariosOcupados.Any(horario =>
                    Math.Abs((horario - i).TotalMinutes) < 20
                );
            return dentroDelRango;

        }


        public Dictionary<DateTime, List<Turno>> SortTurnosByDay(List<Turno> turnos)
        {
            Dictionary<DateTime, List<Turno>> turnosByDay = turnos.GroupBy(t => t.Fecha.Date).ToDictionary(g => g.Key, g => g.ToList());
            return turnosByDay;
        }

        public async Task<List<TurnoHorarioDisponibleResponseDTO>> TurnosDisponiblesByMedico(int medicoId)
        {
            var proceso = Process.GetCurrentProcess();

            // Obtener los datos necesarios
            var horariosDisponibilidadMedico = await _unitOfWork.DisponibilidadMedicoRepository.GetByMedico(medicoId);
            var turnos = await _unitOfWork.TurnoRepository.FilterByDoctor(medicoId, EstadoTurno.Programada);

            // Lógica para generar los horarios disponibles
            List<TurnoHorarioDisponibleResponseDTO> horariosDisponibles = new GeneradorHorariosDisponibles().GenerarHorariosDisponiblesPorMes(medicoId, turnos, horariosDisponibilidadMedico);

            long memoriaDespues = proceso.WorkingSet64;
            double cpuDespues = proceso.TotalProcessorTime.TotalMilliseconds;

            return horariosDisponibles;
        }

        public async Task<List<TurnoHorarioDisponibleResponseDTO>> TurnosDisponiblesByEspecialidad(string especialidad)
        {

            var medicosEspecialidad = await _unitOfWork.MedicoRepository.FilterByEspecialidad(especialidad);
            if (!medicosEspecialidad.Any()) throw new Exception(ErrorMessages.EspecialdiadNotFound);

            var turnosDisponibles = new List<TurnoHorarioDisponibleResponseDTO>();
            GeneradorHorariosDisponibles GenerarHorarios = new GeneradorHorariosDisponibles();

            foreach (Medico medico in medicosEspecialidad)
            {
                var horariosDisponibilidadMedico = await _unitOfWork.DisponibilidadMedicoRepository.GetByMedico(medico.Id);
                var turnos = await _unitOfWork.TurnoRepository.FilterByDoctor(medico.Id, EstadoTurno.Programada);
                turnosDisponibles.AddRange(GenerarHorarios.GenerarHorariosDisponiblesPorMes(medico.Id, turnos, horariosDisponibilidadMedico));

            }
            return turnosDisponibles;

        }

        public async Task<TurnoResponseDTO> CancelarTurno(int idTurno)
        {

            var turno = await _unitOfWork.TurnoRepository.GetById(idTurno);
            if (turno != null)
            {
                turno.Estado = EstadoTurno.Cancelada;
                await _unitOfWork.Save();

            }
            var rsta = _mapper.Map<TurnoResponseDTO>(turno);
            return rsta;
        }

        public async Task<TurnoResponseDTO> ActualizarEstadoTurno(int idTurno, EstadoTurno estadoTurno)
        {
            var turno = await _unitOfWork.TurnoRepository.GetById(idTurno);
            if (turno != null)
            {
                turno.Estado = estadoTurno;
                await _unitOfWork.Save();
            }
            var rsta = _mapper.Map<TurnoResponseDTO>(turno);
            return rsta;
        }

        public async Task<List<TurnoResponseDTO>> DoctorTurnosByDate(DateTime dt, int idMedico)
        {
            var turnos = await _unitOfWork.TurnoRepository.DoctorTurnosByDate(dt, idMedico);
            var rsta = _mapper.Map<List<TurnoResponseDTO>>(turnos);
            return rsta;
        }
    }
}
