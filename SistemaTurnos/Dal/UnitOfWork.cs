using PatronRepositorio_UnitOfWork.Dal.Data;
using PatronRepositorio_UnitOfWork.Dal.Repository.Interface;

namespace PatronRepositorio_UnitOfWork.Dal
{
    public class UnitOfWork : IUnitOfWork
    {
        public IPersonaRepository PersonaRepository { get; }
        private readonly DataContext _context;
        public UnitOfWork(DataContext context, IPersonaRepository personaRepository)
        {
            _context = context;
            PersonaRepository = personaRepository;
        }

        public async Task<int> Save()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
