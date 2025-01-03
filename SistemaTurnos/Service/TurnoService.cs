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
using System.Security.Cryptography;
using Microsoft.AspNetCore.Server.IIS.Core;
using Microsoft.Data.SqlClient;
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
        public bool suma(int a, int b)
        {
            return a == b;
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

        public async Task<List<HorarioMedicoLibreResponseDTO>> ObtenerHorariosDisponibles(int medicoId)
        {
            var disponibilidades = await _unitOfWork.DisponibilidadMedicoRepository.GetByMedico(medicoId);
            var turnos = await _unitOfWork.TurnoRepository.FilterByDoctor(medicoId);

            var fechaInicio = DateTime.Today;
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

                        //si el tiempo es menor al inicio del turno crea una nueva franja horaria
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
                    //es para la utlima franja horaria entre el ultimo turno y la finalizacion del la jornada laboral
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

        public TurnoHorarioDisponibleResponseDTO ObtenerHorariosDisponiblesPorDisponibilidad(DisponibilidadMedico disp, List<Turno> turnos,
            DateTime dia, TurnoHorarioDisponibleResponseDTO horarioDisponible)
        {
            TimeSpan startShift = disp.StartTime;
            TimeSpan endShift = disp.EndTime;
            TimeSpan tiempoTurno = new TimeSpan(0, 20, 0);

            DateTime fechaReferencia = DateTime.Today.Add(startShift);
            DateTime finTurno = fechaReferencia.Add(tiempoTurno);


            // Crear un HashSet con los horarios ocupados para acceso rápido
            var horariosOcupados = new HashSet<TimeSpan>(
                turnos.Select(t => t.Fecha.TimeOfDay)
            );
            //recorre cada franja de tiempo disponible (en relacion con el tiempo del turno) para ver sie sta disponible

            // Llenar la lista de horarios disponibles
            //valida justo el horario en que cae cada 20 min, si por algun motivo se hardcodio un turno va a haber una sobreposicion
  
            for (TimeSpan i = startShift; i < endShift; i += tiempoTurno)
            {

                // Validar si hay un horario en el rango de ±20 minutos


                if (!horariosOcupados.Contains(i))
                {
                    horarioDisponible.Horario.Add(i);
                }
            }
            return horarioDisponible;
        }

            public TurnoHorarioDisponibleResponseDTO GenerarHorariosDisponiblesPorDia(List<DisponibilidadMedico> horariosDisponibilidadMedico,
            List<Turno> turnos,DateTime dia, int medicoId)
        {
            var horarioDisponible = new TurnoHorarioDisponibleResponseDTO();
            horarioDisponible.MedicoId = medicoId;
            horarioDisponible.Fecha = dia;

            var turnosDia = turnos.Where(turno => turno.Fecha.Day == dia.Day).ToList();

            foreach (var disp in horariosDisponibilidadMedico)
            {
                ObtenerHorariosDisponiblesPorDisponibilidad(disp, turnosDia, dia,horarioDisponible);
            }
            // Ordenar para garantizar consistencia en los tests
            horarioDisponible.Horario = horarioDisponible.Horario
                .OrderBy(h => h)
                .ToList();
            return horarioDisponible;
            }


        public List<TurnoHorarioDisponibleResponseDTO> GenerarHorariosDisponiblesPorMes(int medicoId, List<Turno> turnos,
            List<DisponibilidadMedico> horariosDisponibilidadMedico)
        {
            var fechaInicio = DateTime.Today;

            var transformFechaFin = fechaInicio.AddMonths(1);
            //reccorre hasta fin de mes
            var fechaFin = new DateTime(transformFechaFin.Year, transformFechaFin.Month, transformFechaFin.Day);
            Console.WriteLine("/////////////////////////////////////////////////////");
            Console.WriteLine(fechaInicio);
            Console.WriteLine(fechaFin);

            var horariosDisponiblesPorDia = new List<TurnoHorarioDisponibleResponseDTO>();

            // Procesar cada día del mes
            for (var dia = fechaInicio.Date; dia <= fechaFin.Date; dia = dia.AddDays(1))
            {
                var disponibilidadDelDia = horariosDisponibilidadMedico.Where(d => d.DiaSemanaId == dia.Day).ToList();
                if (!disponibilidadDelDia.Any()) continue;
                var horariosDia = GenerarHorariosDisponiblesPorDia(disponibilidadDelDia, turnos, dia, medicoId);
                if (horariosDia != null)
                {
                    horariosDisponiblesPorDia.Add(horariosDia);
                }
            }
            return horariosDisponiblesPorDia;
        }

        public Dictionary<DateTime, List<Turno>> SortTurnosByDay(List<Turno> turnos)
        {
            Dictionary<DateTime, List<Turno>> turnosByDay = turnos.GroupBy(t => t.Fecha.Date).ToDictionary(g => g.Key, g => g.ToList());
            return turnosByDay;
        }
        public async Task<List<TurnoHorarioDisponibleResponseDTO>> TurnosDisponiblesByMedico(int medicoId)
        {
            var proceso = Process.GetCurrentProcess();

            // Obtener la memoria y el CPU antes de la ejecución
            long memoriaAntes = proceso.WorkingSet64;
            double cpuAntes = proceso.TotalProcessorTime.TotalMilliseconds;

            var stopwatch = Stopwatch.StartNew();

            // Obtener los datos necesarios
            var horariosDisponibilidadMedico = await _unitOfWork.DisponibilidadMedicoRepository.GetByMedico(medicoId);
            var turnos = await _unitOfWork.TurnoRepository.FilterByDoctor(medicoId, EstadoTurno.Programada);

            // Lógica para generar los horarios disponibles
            List<TurnoHorarioDisponibleResponseDTO> horariosDisponibles = GenerarHorariosDisponiblesPorMes(medicoId, turnos, horariosDisponibilidadMedico);

            // Obtener la memoria y el CPU después de la ejecución
            proceso.Refresh(); // Refresca la información del proceso
            long memoriaDespues = proceso.WorkingSet64;
            double cpuDespues = proceso.TotalProcessorTime.TotalMilliseconds;

            // Detener el cronómetro
            stopwatch.Stop();

            // Mostrar el tiempo de ejecución y recursos utilizados en la consola
            Console.WriteLine($"Tiempo de ejecución: {stopwatch.ElapsedMilliseconds} ms");
            Console.WriteLine($"Memoria utilizada: {(memoriaDespues - memoriaAntes) / 1024} KB");
            Console.WriteLine($"CPU utilizado: {cpuDespues - cpuAntes} ms");

            return horariosDisponibles;
        }

        public async Task<List<TurnoHorarioDisponibleResponseDTO>> TurnosDisponiblesByEspecialidad(string especialidad)
        {   

            var medicosEspecialidad = await _unitOfWork.MedicoRepository.FilterByEspecialidad(especialidad);
            if (!medicosEspecialidad.Any()) throw new Exception(ErrorMessages.EspecialdiadNotFound);

            var turnosDisponibles = new List<TurnoHorarioDisponibleResponseDTO>();
            foreach(Medico medico in medicosEspecialidad)
            {
                var horariosDisponibilidadMedico = await _unitOfWork.DisponibilidadMedicoRepository.GetByMedico(medico.Id);
                var turnos = await _unitOfWork.TurnoRepository.FilterByDoctor(medico.Id, EstadoTurno.Programada);
                turnosDisponibles.AddRange(GenerarHorariosDisponiblesPorMes(medico.Id, turnos, horariosDisponibilidadMedico));

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
            if(turno != null)
            {
                turno.Estado = estadoTurno;
                await _unitOfWork.Save();
            }
            var rsta = _mapper.Map<TurnoResponseDTO>(turno);
            return rsta;
        }

        public async Task<List<TurnoResponseDTO>> DoctorTurnosByDate(DateTime dt,int idMedico)
        {
            var turnos = await _unitOfWork.TurnoRepository.DoctorTurnosByDate(dt,idMedico);
            var rsta = _mapper.Map<List<TurnoResponseDTO>>(turnos);
            return rsta;
        }
    }
}
