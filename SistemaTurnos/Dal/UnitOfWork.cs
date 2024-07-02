using SistemaTurnos.Dal.Data;
using SistemaTurnos.Dal.Repository.Interface;

namespace SistemaTurnos.Dal
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;

        public IPersonaRepository PersonaRepository { get; }

        public IPacienteRepository PacienteRepository { get; }

        public UnitOfWork(DataContext context, IPacienteRepository pacienteRepository, IPersonaRepository personaRepository)
        {
            _context = context;
            PacienteRepository = pacienteRepository;
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
