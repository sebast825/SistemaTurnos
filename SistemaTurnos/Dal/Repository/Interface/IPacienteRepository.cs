using SistemaTurnos.Dal.Entities;

namespace SistemaTurnos.Dal.Repository.Interface
{
    public interface IPacienteRepository : IRepository<Paciente>
    {
        Task<List<Paciente>> GetAll();
        Task<Paciente> GetById(int id);

    }
}
