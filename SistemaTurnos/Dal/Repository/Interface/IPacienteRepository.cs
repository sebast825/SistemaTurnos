using SistemaTurnos.Dal.Entities;

namespace SistemaTurnos.Dal.Repository.Interface
{
    public interface IPacienteRepository
    {
        Task<List<Paciente>> GetAll();

    }
}
