
namespace SistemaTurnos.Dto.Turno
{
    public class TurnoResponseDTO
    {
        public int Id { get; set; }
        public string Medico { get; set; }
        public string Especialidad { get; set; }
        public string Paciente { get; set; }
        public string PacienteDni { get; set; }
        public string Fecha { get; set; }
        public string Estado { get; set; }
        public string FechaCreacion { get; set; }
    }
}
