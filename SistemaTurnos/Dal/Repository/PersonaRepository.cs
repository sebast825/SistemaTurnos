using Microsoft.EntityFrameworkCore;
using SistemaTurnos.Dal.Data;
using SistemaTurnos.Dal.Entities;
using SistemaTurnos.Dal.Repository.Interface;

namespace SistemaTurnos.Dal.Repository
{
    public class PersonaRepository : Repository<Persona>,IPersonaRepository
    {
        public PersonaRepository(DataContext context) : base(context) { }

        public async Task<Persona> GetByDni(string numeroDocumento)
        {
            var persona = await _context.Personas
                .Include(x => x.Sexo)
                .FirstOrDefaultAsync(x => x.NumeroDocumento == numeroDocumento);

            return persona;
        }

      
    }
}
