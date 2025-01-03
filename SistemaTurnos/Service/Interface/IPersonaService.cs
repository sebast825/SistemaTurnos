using SistemaTurnos.Dto.Persona;

namespace SistemaTurnos.Service.Interface
{
    public interface IPersonaService
    {
        //Task<PersonaResponseDTO> ActualizarEstado(int id,int estado);
        //Task<PersonaResponseDTO> ActualizarEstadoEliminar(int id);
        Task<PersonaResponseDTO> ActualizarPersona(int id, PersonaUpdateRequestDTO dto);

        Task<string> GetTipoPersona(int id);
        Task<PersonaResponseDTO> GetById(int id);

        Task<List<PersonaResponseDTO>> GetAllPersonaIncludeInactive();


    }
}
