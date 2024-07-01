using SistemaTurnos.Dal.Repository.Interface;

namespace SistemaTurnos.Dal
{
    public interface IUnitOfWork : IDisposable
    {
        //IPersonaRepository PersonaRepository { get; }
        Task<int> Save();

    }
}
