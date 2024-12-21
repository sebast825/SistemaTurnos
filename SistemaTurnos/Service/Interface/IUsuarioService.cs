using SistemaTurnos.Common;
using SistemaTurnos.Dal.Entities;
using SistemaTurnos.Dal.Repository.Interface;
using SistemaTurnos.Dto.Persona;

namespace SistemaTurnos.Service.Interface
{
    public interface IUsuarioService 
    {
        Task<PersonaResponseDTO> UpdateEstado(int id, EstadoUsuario estado);
    }
}
