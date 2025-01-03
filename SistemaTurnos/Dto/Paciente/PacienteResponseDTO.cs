using SistemaTurnos.Dto.Persona;

namespace SistemaTurnos.Dto.Paciente
{
    public class PacienteResponseDTO : PersonaResponseDTO
    {

        public string TelefonoEmergencia { get; set; }
        public string NombreEmergencia { get; set; }
    }
}
