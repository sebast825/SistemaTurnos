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

        public Task<List<DisponibilidadMedico>> FilterByEspecialidad(int idEspecialidad)
        {
            throw new NotImplementedException();
        }

        public Task<List<DisponibilidadMedico>> GetByMedico(int idMedico)
        {
            throw new NotImplementedException();
        }
        public  async Task<List<DisponibilidadMedico>> GetAll()
        {

          
            var disponibilidadMedicos = await _context.DisponibilidadMedicos
                     .Include(s => s.Medico)

                    .Include(x => x.DiaSemana)
                    .Where(s => s.Medico.EstadoUsuarioId == _idMedicosActivos)
                    .ToListAsync();
            Console.WriteLine("lp");
           

            return disponibilidadMedicos;
        }
    }
}
