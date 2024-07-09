namespace SistemaTurnos.Dal.Entities
{
    public class Turno : ClaseBase
    {
        public Turno() {
            Estado = EstadoTurno.Programada;
            FechaCreacion = DateTime.Now;
        }
        public int MedicoId { get; set; }
        public Medico Medico { get; set; }
        public int PacienteId { get; set; }
        public Paciente Paciente { get; set; }

        public DateTime Fecha { get; set; }

        public EstadoTurno Estado { get; set; }

        public DateTime FechaCreacion { get; set; }
    }
}

public enum EstadoTurno
{
    Programada,
    Cancelada,
    Completada,
    LLamando,
    EnProgreso,
    Finalizada,
    NoAsistida
}