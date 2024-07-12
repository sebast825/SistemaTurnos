using SistemaTurnos.Dto.Persona;

namespace SistemaTurnos.Dto.Administrativo
{
    public class AdministrativoRequestCreateDTO : PersonaCreateRequestDTO
    {
        public int RolId { get; set; }

    }
}
