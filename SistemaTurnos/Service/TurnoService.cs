using AutoMapper;
using SistemaTurnos.Dal;
using SistemaTurnos.Dto.Turno;
using SistemaTurnos.Service.Interface;
using SistemaTurnos.Common;
using SistemaTurnos.Dal.Entities;

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

        public async Task<List<TurnoResponseDTO>> FilterByDoctor(int id)
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
                throw new Exception(ErrorMessages.MedicoNotFound);

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

        public async Task<DisponibilidadMedicoTurnoResponseDTO> ObtenerHorariosDisponibles(int medicoId)
        {
            //int diaSemanaId = (int)fecha.DayOfWeek;

            var disponibilidades = await _unitOfWork.DisponibilidadMedicoRepository.GetByMedico(medicoId);
            var turnos = await _unitOfWork.TurnoRepository.FilterByDoctor(medicoId);
            /*  string diaSemana = fecha.DayOfWeek.ToString();

              bool diaSemanaExiste = Enum.TryParse<DayOfWeekEnum>(diaSemana, out DayOfWeekEnum result);
              int indiceDiaSemana = (int)result;*/

            
            var fechaInicio = DateTime.Today;
            //var fechaFin = DateTime.Today.AddMonths(1).AddDays(-1);
            var fechaFin = DateTime.Today.AddDays(10);



            var horariosDisponiblesPorDia = new DisponibilidadMedicoTurnoResponseDTO();
            horariosDisponiblesPorDia.IdMedico = medicoId;
             horariosDisponiblesPorDia.Medico= "nombreMedico";
            horariosDisponiblesPorDia.Disponibilidades = new List<HorarioDisponibilidadTurnoDTO>();
            // Procesar cada día del mes
            for (var dia = fechaInicio.Date; dia <= fechaFin.Date; dia = dia.AddDays(1))
            {
                int diaSemanaId = (int)dia.DayOfWeek;

                // Filtrar disponibilidades y turnos para el día específico
                var disponibilidadDelDia = disponibilidades.Where(d => d.DiaSemanaId == diaSemanaId).ToList();
                var turnosDelDia = turnos.Where(t => t.Fecha.Date == dia.Date).ToList();


                foreach (var disp in disponibilidadDelDia)
                {
                    TimeSpan start = disp.StartTime;
                    foreach (var turno in turnosDelDia)
                    {
                        TimeSpan turnoInicio = turno.Fecha.TimeOfDay;
                        TimeSpan turnoFin = turnoInicio.Add(TimeSpan.FromMinutes(20)); // Duración estimada de un turno
                        var horarioDisponible = new HorarioDisponibilidadTurnoDTO();

                        if (start < turnoInicio)
                        {


                            horarioDisponible.Fecha = dia;
                            horarioDisponible.HoraInicio = start;
                            horarioDisponible.HoraFin = turnoInicio;

                            //horariosDisponibles.Add((start, turnoInicio));
                            horariosDisponiblesPorDia.Disponibilidades.Add(horarioDisponible);

                        }

                        start = turnoFin;
                    }

                    if (start < disp.EndTime)
                    {
                        var horarioDisponible = new HorarioDisponibilidadTurnoDTO();


                        horarioDisponible.Fecha = dia;
                        horarioDisponible.HoraInicio = start;
                        horarioDisponible.HoraFin = disp.EndTime;
                        //horariosDisponibles.Add((start, disp.EndTime));
                        horariosDisponiblesPorDia.Disponibilidades.Add(horarioDisponible);

                    }
                }
               
                

            }

            return horariosDisponiblesPorDia;
        }


    }
}


/*


var fechaInicio = DateTime.Today;
//var fechaFin = DateTime.Today.AddMonths(1).AddDays(-1);
var fechaFin = DateTime.Today.AddDays(1);



var horariosDisponiblesPorDia = new DisponibilidadMedicoTurnoResponseDTO();

// Procesar cada día del mes
for (var dia = fechaInicio.Date; dia <= fechaFin.Date; dia = dia.AddDays(1))
{
    int diaSemanaId = (int)dia.DayOfWeek;

    // Filtrar disponibilidades y turnos para el día específico
    var disponibilidadDelDia = disponibilidades.Where(d => d.DiaSemanaId == diaSemanaId).ToList();
    var turnosDelDia = turnos.Where(t => t.Fecha.Date == dia.Date).ToList();

    var horariosDisponibles = new List<(TimeSpan StartTime, TimeSpan EndTime)>();

    foreach (var disp in disponibilidadDelDia)
    {
        TimeSpan start = disp.StartTime;
        foreach (var turno in turnosDelDia)
        {
            TimeSpan turnoInicio = turno.Fecha.TimeOfDay;
            TimeSpan turnoFin = turnoInicio.Add(TimeSpan.FromMinutes(20)); // Duración estimada de un turno

            if (start < turnoInicio)
            {
                horariosDisponibles.Add((start, turnoInicio));
            }

            start = turnoFin;
        }

        if (start < disp.EndTime)
        {
            horariosDisponibles.Add((start, disp.EndTime));
        }
    }

    if (horariosDisponibles.Any())
    {
        horariosDisponiblesPorDia[dia] = horariosDisponibles;
    }
}

return horariosDisponiblesPorDia;
*/