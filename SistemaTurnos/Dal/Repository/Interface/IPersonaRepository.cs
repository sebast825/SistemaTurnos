using SistemaTurnos.Dal.Entities;

namespace SistemaTurnos.Dal.Repository.Interface
{
    public interface IPersonaRepository
    {
        Task<List<Persona>> GetByID(int id);
    }
}
