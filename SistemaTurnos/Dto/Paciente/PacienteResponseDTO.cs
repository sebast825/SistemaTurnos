using SistemaTurnos.Dal.Entities;

namespace SistemaTurnos.Dto.Paciente
{
    public class PacienteResponseDTO
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Telefono { get; set; }
        public string NumeroDocumento { get; set; }
        public string Email { get; set; }
        public Sexo Sexo { get; set; }
        public string TelefonoEmergencia { get; set; }
        public string NombreEmergencia { get; set; }
    }
}
