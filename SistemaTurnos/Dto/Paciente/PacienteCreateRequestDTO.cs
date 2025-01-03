using SistemaTurnos.Dto.Persona;

namespace SistemaTurnos.Dto.Paciente
{
    public class PacienteCreateRequestDTO : PersonaCreateRequestDTO
    {

        public string TelefonoEmergencia { get; set; }
        public string NombreEmergencia { get; set; }
    }
}
