using Microsoft.EntityFrameworkCore;
using SistemaTurnos.Common;
using SistemaTurnos.Dal.Data;
using SistemaTurnos.Dal.Entities;
using SistemaTurnos.Dal.Repository.Interface;
using SistemaTurnos.Dto.Paciente;

namespace SistemaTurnos.Dal.Repository
{
    public class PacienteRepository : Repository<Paciente> ,IPacienteRepository
    {

        public PacienteRepository(DataContext context) : base(context)
        {
            
        }
        public async Task<List<Paciente>> GetAll()
        {
        

            var pacientes = await _context.Personas
                   .OfType<Paciente>()
                .Include(v => v.Sexo)
                .Where(s => s.EstadoPersona == EstadoPersona.Activo)
                .ToListAsync();

      

            return pacientes;

        }
    }
}
