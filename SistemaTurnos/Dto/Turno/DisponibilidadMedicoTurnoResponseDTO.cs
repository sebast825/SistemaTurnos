namespace SistemaTurnos.Dto.Turno
{
    public class DisponibilidadMedicoTurnoResponseDTO
    {
        public int IdMedico { get; set; }
        public string Medico { get; set; }
        public List<HorarioDisponibilidadTurnoDTO> Disponibilidades { get; set; }
    }
}


public class HorarioDisponibilidadTurnoDTO
{
    public DateTime Fecha { get; set; }
    public TimeSpan HoraInicio { get; set; }
    public TimeSpan HoraFin { get; set; }
}