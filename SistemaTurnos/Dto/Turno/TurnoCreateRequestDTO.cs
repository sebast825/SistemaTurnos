namespace SistemaTurnos.Dto.Turno
{
    public class TurnoCreateRequestDTO
    {
        public int MedicoId { get; set; }
        public int PacienteId { get; set; }
        public DateTime Fecha { get; set; }

    }
}
