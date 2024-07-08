using Microsoft.EntityFrameworkCore;
using SistemaTurnos.Dal.Data;
using SistemaTurnos.Dal.Entities;
using SistemaTurnos.Dal.Repository.Interface;
using System.Linq;

namespace SistemaTurnos.Dal.Repository
{
    public class DisponibilidadMedicoRepository : Repository<DisponibilidadMedico>, IDisponibilidadMedicoRepository
    {
        public DisponibilidadMedicoRepository(DataContext context) : base(context)
        {
        }

        public async Task<List<DisponibilidadMedico>> FilterByEspecialidad(int idEspecialidad)
        {
            var disponibilidadMedico = await _context.DisponibilidadMedicos
                                        .Include(s => s.Medico)

                                       .Include(x => x.DiaSemana)
                                       .Where(s => s.Medico.EspecialidadId == idEspecialidad && s.Medico.EstadoUsuarioId == _idMedicosActivos)
                                       .ToListAsync();


            return disponibilidadMedico;
        }

        public async Task<List<DisponibilidadMedico>> GetByMedico(int idMedico)
        {
            var disponibilidadMedico = await _context.DisponibilidadMedicos
                                .Include(s => s.Medico)

                               .Include(x => x.DiaSemana)
                               .Where(s => s.MedicoId == idMedico && s.Medico.EstadoUsuarioId == _idMedicosActivos)
                               .ToListAsync();


            return disponibilidadMedico;
        }
        public  async Task<List<DisponibilidadMedico>> GetAll()
        {

          
            var disponibilidadMedicos = await _context.DisponibilidadMedicos
                     .Include(s => s.Medico)

                    .Include(x => x.DiaSemana)
                    .Where(s => s.Medico.EstadoUsuarioId == _idMedicosActivos)
                    .ToListAsync();
           

            return disponibilidadMedicos;
        }
    }
}
