using SistemaTurnos.Dal.Entities;
using SistemaTurnos.Dto.Login;

namespace SistemaTurnos.Service.Interface
{
    public interface ILogService
    {
        Task<Usuario> GetUsuarioByUserPass(string user, string pass);

        Task<Object> LogIn(LoginRequestDTO login);


    }
}
