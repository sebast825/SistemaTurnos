using Microsoft.EntityFrameworkCore;
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
                                 .Include(x => x.EstadoUsuario)
                                .Where(m => id == m.EspecialidadId && m.EstadoUsuarioId == 1)
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
                    .Include(x => x.EstadoUsuario)
                    .Include(x => x.Especialidad)
                    .Where(s => s.EstadoUsuarioId == 1)
                    .ToListAsync();

            // Convertir List<Persona> a List<medico> si es necesario
            // Esto asume que medico es una subclase de Persona
            // Si quieres devolver específicamente medicos, puedes filtrar aquí
            //var medicos = personas.OfType<Medico>().ToList();

            return medicos;
        }
    }
}
