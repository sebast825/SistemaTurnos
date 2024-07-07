namespace SistemaTurnos.Dal.Entities
{
    public class DisponibilidadMedico : ClaseBase
    {
        public int MedicoId { get; set; }
        public Medico Medico { get; set; }
        public int DiasSemanaId { get; set; } 
        public DiaSemana DiasSemana { get; set; }
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }

    }
}
