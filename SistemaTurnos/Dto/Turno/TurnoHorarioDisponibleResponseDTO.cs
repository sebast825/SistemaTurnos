namespace SistemaTurnos.Dto.Turno
{
    public class TurnoHorarioDisponibleResponseDTO
    {
        public TurnoHorarioDisponibleResponseDTO() {
            Horario = new List<TimeSpan>();
        }
        public int MedicoId { get; set; }
        public DateTime Fecha { get;set; }
        public List<TimeSpan> Horario { get; set; }

    }
}
