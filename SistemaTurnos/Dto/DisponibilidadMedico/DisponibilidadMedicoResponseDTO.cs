namespace SistemaTurnos.Dto.DisponibilidadMedico
{
    public class DisponibilidadMedicoResponseDTO
    {
        public int Id { get; set; }

        public int MedicoId { get; set; }
        public string Medico { get; set; }
        public string Especialidad { get; set; }
        public string DiaSemana { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
    }
}
