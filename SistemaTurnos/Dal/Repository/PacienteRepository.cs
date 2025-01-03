using Microsoft.EntityFrameworkCore;
using SistemaTurnos.Common;
using SistemaTurnos.Dal.Data;
using SistemaTurnos.Dal.Entities;
using SistemaTurnos.Dal.Repository.Interface;

namespace SistemaTurnos.Dal.Repository
{
    public class PacienteRepository : Repository<Paciente>, IPacienteRepository
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

        public async Task<Paciente> GetById(int id)
        {
            var paciente = await _context.Personas
                    .OfType<Paciente>()
                    .Include(v => v.Sexo)
                    .Where(s => s.EstadoPersona == EstadoPersona.Activo && s.Id == id)
                    .FirstOrDefaultAsync();
            return paciente;
        }
    }
}
