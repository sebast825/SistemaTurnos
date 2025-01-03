namespace SistemaTurnos.Dto.DisponibilidadMedico
{
    public class DisponibilidadMedicoCreateRequestDTO
    {
        public int MedicoId { get; set; }
        public int DiaSemanaId { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
    }
}
