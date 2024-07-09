using Microsoft.EntityFrameworkCore;
using SistemaTurnos.Dal.Data;
using SistemaTurnos.Dal.Entities;
using SistemaTurnos.Dal.Repository.Interface;
using SistemaTurnos.Dto.Turno;

namespace SistemaTurnos.Dal.Repository
{
    public class TurnoRepository : Repository<Turno>, ITurnoRepository
    {
        public TurnoRepository(DataContext context) : base(context)
        {
        }
        public async Task<List<Turno>> GetAll()
        {
            var turnos = await _context.Turnos
                    .Include(x => x.Medico)
                    .Include(p => p.Paciente)
                    .Where(p => p.Paciente.EstadoUsuarioId != _idEstadoUsuarioEliminado)
                    .ToListAsync();
            
            return turnos;

        }

        public async Task<List<Turno>> FilterByDoctor(int id)
        {
            var turnos = await _context.Turnos
                                      .Include(x => x.Medico)
                                      .Include(p => p.Paciente)
                                      .Where(p => p.Paciente.EstadoUsuarioId != _idEstadoUsuarioEliminado
                                              && p.MedicoId == id)
                                      .ToListAsync();

            return turnos;
        }

        public async Task<List<Turno>> FilterByPaciente(int id)
        {
            var turnos = await _context.Turnos
                                    .Include(x => x.Medico)
                                    .Include(p => p.Paciente)
                                    .Where(p => p.Paciente.EstadoUsuarioId != _idEstadoUsuarioEliminado 
                                            && p.PacienteId == id)
                                    .ToListAsync();

            return turnos;
        }

        public async Task<List<Turno>> FilterByEstadoTurno(EstadoTurno estado)
        {
            var turnos = await _context.Turnos
                             .Include(x => x.Medico)
                             .Include(p => p.Paciente)
                             .Where(p => p.Paciente.EstadoUsuarioId != _idEstadoUsuarioEliminado && p.Estado == estado)
                             .ToListAsync();

            return turnos;
        }

        //devuelve los turnos con +/- 20 min, param opcional filtrar por medico
        public async Task<List<Turno>> FilterByDateTime(DateTime dt, int? medicoId = null)
        {  
            // Calcular los límites de tiempo
            DateTime startTime = dt.AddMinutes(-20);
            DateTime endTime = dt.AddMinutes(20);

            var turnosQuery = _context.Turnos
                            .Include(x => x.Medico)
                            .Include(p => p.Paciente)
                            .Where(p => p.Paciente.EstadoUsuarioId != _idEstadoUsuarioEliminado &&
                                p.Fecha >= startTime && p.Fecha <= endTime);
                      
            // Aplicar el filtro opcional por MedicoId
            if (medicoId.HasValue)
            {
                turnosQuery = turnosQuery.Where(p => p.MedicoId == medicoId.Value);
                
            }
            var turnos = await turnosQuery.ToListAsync();
            return turnos;
        }
    }
}
