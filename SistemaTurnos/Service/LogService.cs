
using SistemaTurnos.Service.Interface;
using SistemaTurnos.Dal;
using SistemaTurnos.Dal.Entities;
using Microsoft.AspNetCore.Http.HttpResults;

namespace SistemaTurnos.Service
{
    public class LogService : ILogService
    {
        private readonly IUnitOfWork _unitOfWork;
        public LogService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
      
        }

        public async Task<Usuario> GetUsuarioByUserPass(string user, string pass)
        {
            var usuario = await _unitOfWork.UsuarioRepository.GetByUser(user);
            if (usuario == null)
            {
                //Usuario No Existe
                Console.WriteLine("El usuario no existe");
                return null;
            }
            else if (usuario.Password != pass)
            {
                //Pass err
                Console.WriteLine("Clave invalida");

                return null;
            }
            return usuario;
        }            
    }
}
