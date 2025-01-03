using SistemaTurnos.Dto.Administrativo;

namespace SistemaTurnos.Service.Interface
{
    public interface IAdministrativoService
    {
        Task<AdministrativoResponseDTO> Create(AdministrativoRequestCreateDTO dto);
    }
}
