using Microsoft.AspNetCore.Mvc;
using SistemaTurnos.Dto.Paciente;

namespace SistemaTurnos.Service.Interface
{
    public interface IPacienteService
    {
        Task<List<PacienteResponseDTO>> GetAll();
        Task<PacienteResponseDTO> Create(PacienteCreateRequestDTO paciente);
        Task<List<PacienteResponseDTO>> GetById(int id);
    }
}
