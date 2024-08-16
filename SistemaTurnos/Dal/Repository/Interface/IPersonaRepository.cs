using SistemaTurnos.Dal.Entities;
using SistemaTurnos.Dto.Persona;

namespace SistemaTurnos.Dal.Repository.Interface
{
    public interface IPersonaRepository : IRepository<Persona>
    {
        Task<Persona> GetByDni(string numeroDocumento);
        Task<Persona> GetId(int id);
        Task<Persona> Update(PersonaUpdateRequestDTO dtoUpdate);

    }
}
