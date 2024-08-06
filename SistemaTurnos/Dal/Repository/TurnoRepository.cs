using Microsoft.EntityFrameworkCore;
using SistemaTurnos.Common;
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
                    .Where(p => p.Paciente.EstadoPersona == EstadoPersona.Activo && p.Estado == EstadoTurno.Programada)
                    .ToListAsync();
            
            return turnos;

        }

        public async Task<List<Turno>> FilterByDoctor(int id, EstadoTurno? estadoTurno)
        {
            var turnosQuery = _context.Turnos
                                      .Include(x => x.Medico)
                                      .Include(p => p.Paciente)
                                      .Where(p => p.Paciente.EstadoPersona != EstadoPersona.Inactivo
                                              && p.MedicoId == id);                                   

         
            if (estadoTurno.HasValue)
            {
                turnosQuery = turnosQuery.Where(p => p.Estado == estadoTurno.Value);

            }
            var turnos = await turnosQuery.OrderBy(t => t.Fecha).ToListAsync();

            return turnos;

        }

        public async Task<List<Turno>> FilterByPaciente(int id)
        {
            var turnos = await _context.Turnos
                                    .Include(x => x.Medico)
                                    .Include(p => p.Paciente)
                                    .Where(p => p.Paciente.EstadoPersona != EstadoPersona.Inactivo
                                            && p.PacienteId == id)
                                    .ToListAsync();

            return turnos;
        }

        public async Task<List<Turno>> FilterByEstadoTurno(EstadoTurno estado)
        {
            var turnos = await _context.Turnos
                             .Include(x => x.Medico)
                             .Include(p => p.Paciente)
                             .Where(p => p.Paciente.EstadoPersona != EstadoPersona.Inactivo && p.Estado == estado)
                             .ToListAsync();

            return turnos;
        }

        public async Task<List<Turno>> FilterByDate(DateTime dt, int? medicoId = null)
        {  
            // Calcular los límites de tiempo
            DateTime startTime = dt.AddMinutes(-20);
            DateTime endTime = dt.AddMinutes(20);
            Console.WriteLine(dt.Day);
            var turnosQuery = _context.Turnos
                            .Include(x => x.Medico)
                            .Include(p => p.Paciente)
                            .Where(p => p.Paciente.EstadoPersona != EstadoPersona.Inactivo &&
                                p.Fecha.Day == dt.Day);
                      
            // Aplicar el filtro opcional por MedicoId
            if (medicoId.HasValue)
            {
                turnosQuery = turnosQuery.Where(p => p.MedicoId == medicoId.Value);
                
            }
            var turnos = await turnosQuery.ToListAsync();
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
                            .Where(p => p.Paciente.EstadoPersona != EstadoPersona.Inactivo &&
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
