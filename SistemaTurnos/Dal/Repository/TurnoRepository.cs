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

        public Task<List<Turno>> FilterByDoctor(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Turno>> FilterByPaciente(int id)
        {
            throw new NotImplementedException();
        }
    }
}
