using SistemaTurnos.Dal.Data;
using SistemaTurnos.Dal.Entities;
using SistemaTurnos.Dal.Repository.Interface;

namespace SistemaTurnos.Dal.Repository
{
    public class EstadoUsuarioRepository : Repository<EstadoUsuario>, IEstadoUsuarioRepository
    {
        public EstadoUsuarioRepository(DataContext context) : base(context)
        {
        }
    }
}
