
using SistemaTurnos.Dal.Entities;

namespace SistemaTurnos.Dal.Repository.Interface
{
    public interface IDisponibilidadMedicoRepository : IRepository<DisponibilidadMedico>
    {
        Task<List<DisponibilidadMedico>> GetAll();
        Task<List<DisponibilidadMedico>> GetByMedico(int idMedico);
        Task<List<DisponibilidadMedico>> FilterByEspecialidad(int idEspecialidad);
        Task<List<DisponibilidadMedico>> MedicoIsAviable(int idMedico, int dia, TimeSpan horario);
        Task<DisponibilidadMedico> GetById(int id);


    }
}
