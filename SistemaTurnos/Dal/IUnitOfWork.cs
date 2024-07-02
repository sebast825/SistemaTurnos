using SistemaTurnos.Dal.Repository.Interface;

namespace SistemaTurnos.Dal
{
    public interface IUnitOfWork : IDisposable
    {
        IPersonaRepository PersonaRepository { get; }
        IPacienteRepository PacienteRepository { get; }
        Task<int> Save();

    }
}
