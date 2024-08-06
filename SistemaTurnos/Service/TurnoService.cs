using AutoMapper;
using SistemaTurnos.Dal;
using SistemaTurnos.Dto.Turno;
using SistemaTurnos.Service.Interface;
using SistemaTurnos.Common;
using SistemaTurnos.Dal.Entities;
using SistemaTurnos.Dto.DisponibilidadMedico;
using SistemaTurnos.Dto.Turno;

using System.Collections.Generic;
using System.Runtime.InteropServices;

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

        public async Task<List<HorarioMedicoLibreResponseDTO>> ObtenerHorariosDisponibles(int medicoId)
        {
            //int diaSemanaId = (int)fecha.DayOfWeek;
             await TurnosDisponiblesByMedico(medicoId);
            var disponibilidades = await _unitOfWork.DisponibilidadMedicoRepository.GetByMedico(medicoId);
            var turnos = await _unitOfWork.TurnoRepository.FilterByDoctor(medicoId);

            var fechaInicio = DateTime.Today;
            //var fechaFin = DateTime.Today.AddMonths(1).AddDays(-1);
            var fechaFin = DateTime.Today.AddDays(10);



            var horariosDisponiblesPorDia = new List<HorarioMedicoLibreResponseDTO>();


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
                        var horarioDisponible = new HorarioMedicoLibreResponseDTO();

                        if (start < turnoInicio)
                        {

                            horarioDisponible.IdMedico = medicoId;
                            horarioDisponible.Fecha = dia;
                            horarioDisponible.HoraInicio = start;
                            horarioDisponible.HoraFin = turnoInicio;

                            //horariosDisponibles.Add((start, turnoInicio));
                            horariosDisponiblesPorDia.Add(horarioDisponible);

                        }

                        start = turnoFin;
                    }

                    if (start < disp.EndTime)
                    {
                        var horarioDisponible = new HorarioMedicoLibreResponseDTO();

                        horarioDisponible.IdMedico = medicoId;

                        horarioDisponible.Fecha = dia;
                        horarioDisponible.HoraInicio = start;
                        horarioDisponible.HoraFin = disp.EndTime;
                        //horariosDisponibles.Add((start, disp.EndTime));
                        horariosDisponiblesPorDia.Add(horarioDisponible);

                    }
                }



            }

            return horariosDisponiblesPorDia;
        }

        public async Task<List<TurnoHorarioDisponibleResponseDTO>> TurnosDisponiblesByMedico(int medicoId)
        {
            var horariosDisponibilidadMedico = await _unitOfWork.DisponibilidadMedicoRepository.GetByMedico(medicoId);
            var turnos = await _unitOfWork.TurnoRepository.FilterByDoctor(medicoId);

          var fechaInicio = DateTime.Today;
            //var fechaFin = DateTime.Today.AddMonths(1).AddDays(-1);
            var fechaFin = DateTime.Today.AddDays(10);
            var horariosDisponiblesPorDia = new List<TurnoHorarioDisponibleResponseDTO>();
            var asd = turnos[0].Fecha.DayOfWeek;
           
            
            // Procesar cada día del mes
            for (var dia = fechaInicio.Date; dia <= fechaFin.Date; dia = dia.AddDays(1))
            {
                int diaSemanaId = (int)dia.DayOfWeek;

                // Filtrar disponibilidades y turnos para el día específico
                var disponibilidadDelDia = horariosDisponibilidadMedico.Where(d => d.DiaSemanaId == diaSemanaId).ToList();

                var horarioDisponible = new TurnoHorarioDisponibleResponseDTO();
                horarioDisponible.MedicoId = medicoId;
                horarioDisponible.Fecha = dia;
                


                foreach (var disp in disponibilidadDelDia)
                {
                    TimeSpan startShift = disp.StartTime;
                    TimeSpan endShift = disp.EndTime;
                    TimeSpan tiempoTurno = new TimeSpan(0, 20, 0);
                    //TimeSpan comienzoTurno = startShift;
                    DateTime fechaReferencia = DateTime.Today.Add(startShift);
                    DateTime finTurno = fechaReferencia.Add(tiempoTurno);

                    var turnosDia = turnos.Where(turno => turno.Fecha.Day == dia.Day).ToList();


                    //TimeSpan turnoInicio = turno.Fecha.TimeOfDay;
                    //TimeSpan endShift= startShift.Add(TimeSpan.FromMinutes(20)); // Duración estimada de un turno
                  
                    
                    for (TimeSpan i = startShift; i < endShift; i += tiempoTurno)
                    {
                        var r = i;
                        var hayTurno = turnosDia.Where((turno) =>{
                            var diferenciaDeTiempoTurnoPrevio = (turno.Fecha.TimeOfDay - i).Duration();
                        var diferenciaDeTiempoTurnoProximo = (i - turno.Fecha.TimeOfDay).Duration();
                            if(diferenciaDeTiempoTurnoPrevio < tiempoTurno || diferenciaDeTiempoTurnoProximo < tiempoTurno)
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                            
                        }).ToList();
                        if (hayTurno.Count == 0)
                        {
                            horarioDisponible.Horario.Add(i);

                            Console.WriteLine("hola");
                        }
                        else
                        {

                        }
                        
                      
                        //var medicoDisponible = await _unitOfWork.DisponibilidadMedicoRepository.MedicoIsAviable(dto.MedicoId, indiceDiaSemana, tiempo);
                        //var asd = medicoDisponible.Count() > 0 ? true : false;
                    }

                    //if (startShift)
                    //{



                    //}

                    horariosDisponiblesPorDia.Add(horarioDisponible);


                }
                if (horarioDisponible.Horario.Count > 0)
                {
                    //horariosDisponiblesPorDia.Add(horarioDisponible);

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