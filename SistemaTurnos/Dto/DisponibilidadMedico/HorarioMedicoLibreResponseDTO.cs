namespace SistemaTurnos.Dto.DisponibilidadMedico
{
    public class HorarioMedicoLibreResponseDTO
    {
        public int IdMedico { get; set; }
        public DateTime Fecha { get; set; }
        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraFin { get; set; }
    }
}

