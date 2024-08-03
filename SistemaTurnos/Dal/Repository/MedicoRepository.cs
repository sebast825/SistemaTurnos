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
            var asd = await GetAll();
            var filtrados = asd.Where(j => j.EspecialidadId == id);

            var medicos = await _context.Personas
                                .OfType<Medico>()
                                  .Include(v => v.Sexo)
                                .Where(m => id == m.EspecialidadId && m.EstadoPersona == EstadoPersona.Activo)
                                .Include(x => x.Especialidad)
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
    }
}
