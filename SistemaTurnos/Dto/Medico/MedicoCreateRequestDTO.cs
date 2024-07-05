using SistemaTurnos.Dto.Persona;

namespace SistemaTurnos.Dto.Medico
{
    public class MedicoCreateRequestDTO : PersonaCreateRequestDTO
    {
        public string NumeroLicencia { get; set; }
        public int EspecialidadId { get; set; }
    }
}
