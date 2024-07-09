
using SistemaTurnos.Dal.Entities;

namespace SistemaTurnos.Dal.Repository.Interface
{
    public interface IDisponibilidadMedicoRepository : IRepository<DisponibilidadMedico>
    {
        Task<List<DisponibilidadMedico>>  GetAll();
        Task<List<DisponibilidadMedico>> GetByMedico(int idMedico);
        Task<List<DisponibilidadMedico>> FilterByEspecialidad(int idEspecialidad);
    }
}
