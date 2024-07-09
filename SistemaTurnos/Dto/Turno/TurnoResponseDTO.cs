
namespace SistemaTurnos.Dto.Turno
{
    public class TurnoResponseDTO
    {
        public string Medico { get; set; }
        public string Paciente { get; set; }
        public string PacienteDni { get; set; }
        public DateTime Fecha { get; set; }
        public string Estado { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}
