namespace SistemaTurnos.Dal.Entities
{
    public class DisponibilidadMedico : ClaseBase
    {
        public int MedicoId { get; set; }
        public Medico Medico { get; set; }
        public int DiaSemanaId { get; set; }
        public DiaSemana DiaSemana { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }

    }
}
