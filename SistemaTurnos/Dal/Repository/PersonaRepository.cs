using SistemaTurnos.Dal.Entities;
using SistemaTurnos.Dal.Repository.Interface;

namespace SistemaTurnos.Dal.Repository
{
    public class PersonaRepository : IPersonaRepository
    {
        public Task<List<Persona>> GetByID(int id)
        {
            throw new NotImplementedException();
        }
    }
}
