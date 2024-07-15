using SistemaTurnos.Dal.Entities;

namespace SistemaTurnos.Service.Interface
{
    public interface ILogService
    {
        Task<Usuario> GetUsuarioByUserPass(string user, string pass);
    }
}
