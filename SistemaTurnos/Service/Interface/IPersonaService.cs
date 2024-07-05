using Microsoft.AspNetCore.Mvc;
using SistemaTurnos.Dto.Paciente;
using SistemaTurnos.Dto.Persona;

namespace SistemaTurnos.Service.Interface
{
    public interface IPersonaService
    {
        Task<PersonaResponseDTO> ActualizarEstado(int dni,int estado);
        Task<PersonaResponseDTO> ActualizarEstadoEliminar(int dni);
        Task<PersonaResponseDTO> ActualizarPersona(int id, PersonaUpdateRequestDTO dto);

    }
}
