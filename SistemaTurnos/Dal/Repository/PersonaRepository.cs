using Microsoft.EntityFrameworkCore;
using SistemaTurnos.Common;
using SistemaTurnos.Dal.Data;
using SistemaTurnos.Dal.Entities;
using SistemaTurnos.Dal.Repository.Interface;
using SistemaTurnos.Dto.Persona;

namespace SistemaTurnos.Dal.Repository
{
    public class PersonaRepository : Repository<Persona>,IPersonaRepository
    {
        public PersonaRepository(DataContext context) : base(context) { }

        public async Task<Persona> GetByDni(string numeroDocumento)
        {
            var persona = await _context.Personas
                .Include(x => x.Sexo)
                .Where(m => m.NumeroDocumento == numeroDocumento && m.EstadoPersona == EstadoPersona.Activo)
                .FirstOrDefaultAsync();

            return persona;
        }

        public async Task<Persona> GetId(int id)
        {
            var persona = await _context.Personas
                        .Include(x => x.Sexo)
                        .Where(i => i.Id == id)
                        .FirstAsync();

            return persona;
        }

        public Task<Persona> Update(PersonaUpdateRequestDTO dtoUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
