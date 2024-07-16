using Microsoft.EntityFrameworkCore;
using SistemaTurnos.Common;
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
                .Include(s => s.EstadoPersona)
                .Where(m => m.NumeroDocumento == numeroDocumento && m.EstadoPersona != EstadoPersona.Activo)
                .FirstOrDefaultAsync();

            return persona;
        }

        public async Task<Persona> GetId(int id)
        {
            var persona = await _context.Personas
                        .Include(x => x.Sexo)
                        .Include(s => s.EstadoPersona)
                        .Where(m => m.Id == id && m.EstadoPersona != EstadoPersona.Inactivo)
                        .FirstOrDefaultAsync();

            return persona;
        }
    }
}
