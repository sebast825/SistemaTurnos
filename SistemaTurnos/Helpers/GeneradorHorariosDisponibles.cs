using SistemaTurnos.Dal.Entities;
using SistemaTurnos.Dto.Turno;

namespace SistemaTurnos.Helpers
{
    public class GeneradorHorariosDisponibles
    {


        public TurnoHorarioDisponibleResponseDTO ObtenerHorariosDisponiblesPorDisponibilidad(DisponibilidadMedico disp, List<Turno> turnos,
            TurnoHorarioDisponibleResponseDTO horarioDisponible)
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
        List<Turno> turnos, int medicoId)
        {
            var horarioDisponible = new TurnoHorarioDisponibleResponseDTO();
            horarioDisponible.MedicoId = medicoId;
            horarioDisponible.Fecha = 

            foreach (var disp in horariosDisponibilidadMedico)
            {
                ObtenerHorariosDisponiblesPorDisponibilidad(disp, turnos, horarioDisponible);
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
                var horariosDia = GenerarHorariosDisponiblesPorDia(disponibilidadDelDia, turnos, medicoId);
                if (horariosDia != null)
                {
                    horariosDisponiblesPorDia.Add(horariosDia);
                }
            }
            return horariosDisponiblesPorDia;
        }
    }
}
