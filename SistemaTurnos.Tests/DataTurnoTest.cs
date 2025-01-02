using SistemaTurnos.Dal.Entities;
using SistemaTurnos.Dto.Turno;


namespace SistemaTurnos.Tests
{
    internal class DataTurnoTest

    {
        public static DisponibilidadMedico GetDisponibilidadMedico() => new()
        {
            MedicoId = 5,
            DiaSemanaId = 3,
            StartTime = new TimeSpan(13, 0, 0),
            EndTime = new TimeSpan(14, 0, 0)
        };

        public static List<Turno> GetTurnos() => new()
        {
            new Turno
            {
                MedicoId = 5,
                PacienteId = 3,
                Fecha = DateTime.Now.AddDays(1)
            },
            new Turno
            {
                MedicoId = 5,
                PacienteId = 3,
                Fecha = DateTime.Now.AddDays(1)
            }
        };

        public static List<TimeSpan> GetHorariosEsperados() => new()
        {
            new TimeSpan(13, 0, 0),
            new TimeSpan(13, 20, 0),
            new TimeSpan(13, 40, 0)
        };

        public static TurnoHorarioDisponibleResponseDTO GetHorariosDisponiblesDTO() => new()
        {
            MedicoId = 5,
            Fecha = DateTime.Now
        };
    }
}


