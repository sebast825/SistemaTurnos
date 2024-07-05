using SistemaTurnos.Dto.Medico;

namespace SistemaTurnos.Service.Interface
{
    public interface IMedicoService
    {
        Task<List<MedicoResponseDTO>> GetAll();
        Task<MedicoResponseDTO> Create(MedicoCreateRequestDTO medico);
    }
}
