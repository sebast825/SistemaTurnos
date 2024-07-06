using SistemaTurnos.Dal.Entities;

namespace SistemaTurnos.Dal.Repository.Interface
{
    public interface IPersonaRepository : IRepository<Persona>
    {
        Task<Persona> GetByDni(string numeroDocumento);
        Task<Persona> GetId(int id);

    }
}
