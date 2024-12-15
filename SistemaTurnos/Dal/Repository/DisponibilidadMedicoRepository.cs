using Microsoft.EntityFrameworkCore;
using SistemaTurnos.Common;
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
                     .Include(s => s.Medico.Especialidad)

                                       .Include(x => x.DiaSemana)
                                       .Where(s => s.Medico.EspecialidadId == idEspecialidad && s.Medico.EstadoPersona == EstadoPersona.Activo)
                                       .ToListAsync();


            return disponibilidadMedico;
        }

        public async Task<List<DisponibilidadMedico>> GetByMedico(int idMedico)
        {
            var disponibilidadMedico = await _context.DisponibilidadMedicos
                                .Include(s => s.Medico)
                     .Include(s => s.Medico.Especialidad)

                               .Include(x => x.DiaSemana)
                               .Where(s => s.MedicoId == idMedico && s.Medico.EstadoPersona == EstadoPersona.Activo)
                               .ToListAsync();


            return disponibilidadMedico;
        }
        public  async Task<List<DisponibilidadMedico>> GetAll()
        {

          
            var disponibilidadMedicos = await _context.DisponibilidadMedicos
                     .Include(s => s.Medico)
                     .Include(s => s.Medico.Especialidad)
                    .Include(x => x.DiaSemana)
                    .Where(s => s.Medico.EstadoPersona == EstadoPersona.Activo)
                    .ToListAsync();
           

            return disponibilidadMedicos;
        }

        public async Task<List<DisponibilidadMedico>> MedicoIsAviable(int idMedico, int dia, TimeSpan horario)
        {
            var disponibilidadMedico = await _context.DisponibilidadMedicos
                                        .Include(s => s.Medico)
                                                             .Include(s => s.Medico.Especialidad)

                                       .Include(x => x.DiaSemana)
                                       .Where(s => s.MedicoId == idMedico &&
                                       s.Medico.EstadoPersona == EstadoPersona.Activo &&
                                       s.DiaSemanaId == dia 
                                       &&
                                       s.StartTime <= horario && s.EndTime >= horario
                                       
                                       )
                                       .ToListAsync();

            return disponibilidadMedico;
        }
    }
}
