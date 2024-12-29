using SistemaTurnos.Common;
using SistemaTurnos.Dal.Entities;
using SistemaTurnos.Dal.Repository.Interface;
using SistemaTurnos.Dto.Persona;
using SistemaTurnos.Dto.User;

namespace SistemaTurnos.Service.Interface
{
    public interface IUsuarioService 
    {
        Task<PersonaResponseDTO> UpdateEstado(int id, EstadoUsuario estado);
        Task CreatePaciente(UserCreateRequestDTO userDto, int pacietneId);

        Task StartRecoveryPassword(RecoveryEmailRequestDo dto);

    }
}
