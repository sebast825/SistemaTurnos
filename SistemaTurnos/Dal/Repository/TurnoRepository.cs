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
                    .Include(x => x.Medico.Especialidad)
                    .Include(p => p.Paciente)
                    .Where(p => p.Paciente.EstadoPersona == EstadoPersona.Activo)
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
                                    .Include(x => x.Medico.Especialidad)
                                    .Where(p => p.Paciente.EstadoPersona != EstadoPersona.Inactivo
                                            && p.PacienteId == id && p.Estado != EstadoTurno.Cancelada)
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
                                p.Fecha > startTime && p.Fecha < endTime && p.Estado != EstadoTurno.Cancelada);

            // Aplicar el filtro opcional por MedicoId
            if (medicoId.HasValue)
            {
                turnosQuery = turnosQuery.Where(p => p.MedicoId == medicoId.Value);

            }
            var turnos = await turnosQuery.ToListAsync();
            return turnos;
        }

        public async Task<Turno> UpdateEstado(int id, EstadoTurno estadoTurno)
        {
            var updateTurno = await _context.Turnos
                .Where(p => p.Id == id)
                .FirstOrDefaultAsync();
            if (updateTurno != null)
            {
                updateTurno.Estado = estadoTurno;
                await _context.SaveChangesAsync();
            }

            return updateTurno;
        }

        public async Task<List<Turno>> DoctorTurnosByDate(DateTime dt,int medicoId)
        {
                   

            var turnosQuery = _context.Turnos
                            .Include(x => x.Medico)
                            .Include(p => p.Paciente)
                            .Include(e => e.Medico.Especialidad)
                            .Where(p => p.Paciente.EstadoPersona != EstadoPersona.Inactivo &&
                               p.MedicoId == medicoId && p.Fecha.Date == dt.Date);

            var turnos = await turnosQuery.ToListAsync();
            return turnos;
        }
    }
}
