using PatronRepositorio_UnitOfWork.Dal.Repository.Interface;

namespace PatronRepositorio_UnitOfWork.Dal
{
    public interface IUnitOfWork : IDisposable
    {
        IPersonaRepository PersonaRepository { get; }
        Task<int> Save();

    }
}
