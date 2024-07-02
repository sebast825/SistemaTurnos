using SistemaTurnos.Dto.Paciente;

namespace SistemaTurnos.Service.Interface
{
    public interface IPacienteService
    {
        Task<List<PacienteResponseDTO>> GetAll();
    }
}
