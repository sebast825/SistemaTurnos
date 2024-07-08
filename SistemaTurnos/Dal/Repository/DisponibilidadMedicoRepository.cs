using Microsoft.EntityFrameworkCore;
using SistemaTurnos.Dal.Data;
using SistemaTurnos.Dal.Entities;
using SistemaTurnos.Dal.Repository.Interface;

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
        public async Task<List<DisponibilidadMedico>> GetAll()
        {
            //se filtra aca medico si no no puedo encontrarEspecialdiad
            var disponibilidadMedicos = await _context.DisponibilidadMedicos
                 .clude(v => v.Medico)
                    .Include(x => x.DiaSemana)
                    //.Where(s => s.MedicoId == _idMedicosActivos)
                    .ToListAsync();

 

            return disponibilidadMedicos;
        }
    }
}
