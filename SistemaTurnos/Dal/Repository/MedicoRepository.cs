using Microsoft.EntityFrameworkCore;
using SistemaTurnos.Common;
using SistemaTurnos.Dal.Data;
using SistemaTurnos.Dal.Entities;
using SistemaTurnos.Dal.Repository.Interface;

namespace SistemaTurnos.Dal.Repository
{
    public class MedicoRepository : Repository<Medico>, IMedicoRepository
    {

        public MedicoRepository(DataContext context) : base(context)
        {

        }

        public async Task<List<Medico>> FilterByEspecialidad(int id)
        {

            var medicos = await _context.Personas
                                .OfType<Medico>()
                                  .Include(v => v.Sexo)
                                  .Include(x => x.Especialidad)

                                .Where(m => id == m.EspecialidadId && m.EstadoPersona == EstadoPersona.Activo)
                                .ToListAsync();
            return medicos;
        }
        public async Task<List<Medico>> FilterByEspecialidad(string especialidad)
        {

            var medicos = await _context.Personas
                                .OfType<Medico>()
                                  .Include(v => v.Sexo)
                                  .Include(x => x.Especialidad)

                                .Where(m => especialidad == m.Especialidad.Nombre && m.EstadoPersona == EstadoPersona.Activo)
                                .ToListAsync();
            return medicos;
        }
        public async Task<List<Medico>> GetAll()
        {
            //se filtra aca medico si no no puedo encontrarEspecialdiad
            var medicos = await _context.Personas
                    .OfType<Medico>()
                    .Include(v => v.Sexo)
                    .Include(x => x.Especialidad)
                    .Where(s => s.EstadoPersona == EstadoPersona.Activo)
                    .ToListAsync();

            // Convertir List<Persona> a List<medico> si es necesario
            // Esto asume que medico es una subclase de Persona
            // Si quieres devolver específicamente medicos, puedes filtrar aquí
            //var medicos = personas.OfType<Medico>().ToList();

            return medicos;
        }
        public async Task<Medico> GetById(int id)
        {
            var medico = await _context.Personas
                    .OfType<Medico>()
                    .Include(v => v.Sexo)
                    .Include(x => x.Especialidad)
                    .Where(s => s.Id == id)
                    .FirstOrDefaultAsync();

            return medico;
        }
    }
}
