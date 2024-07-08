using SistemaTurnos.Dto.DisponibilidadMedico;
using SistemaTurnos.Dto.Medico;

namespace SistemaTurnos.Service.Interface
{
    public interface IDisponibilidadMedicoService
    {
        Task<List<DisponibilidadMedicoResponseDTO>> GetAll();
        Task<List<DisponibilidadMedicoResponseDTO>> GetByMedico(int idMedico);
        Task<DisponibilidadMedicoResponseDTO> Create(DisponibilidadMedicoCreateRequestDTO dto);
        Task<List<DisponibilidadMedicoResponseDTO>> FilterByEspecialidad(int idEspecialidad);
    }
}
