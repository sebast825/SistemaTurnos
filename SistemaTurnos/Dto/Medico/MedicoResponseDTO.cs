using SistemaTurnos.Dto.Persona;

namespace SistemaTurnos.Dto.Medico
{
    public class MedicoResponseDTO : PersonaResponseDTO
    {
        public string NumeroLicencia { get; set; }
        public string Especialidad { get; set; }
    }
}
