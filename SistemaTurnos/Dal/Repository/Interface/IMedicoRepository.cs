using SistemaTurnos.Dal.Entities;

namespace SistemaTurnos.Dal.Repository.Interface
{
    public interface IMedicoRepository : IRepository<Medico> 
    {
        Task<List<Medico>> GetAll();
        Task<List<Medico>> FilterByEspecialidad(int id);
        Task<List<Medico>> FilterByEspecialidad(string especialidad);
        Task<Medico> GetById(int id);
    }
}
