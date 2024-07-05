using SistemaTurnos.Dal.Data;
using SistemaTurnos.Dal.Entities;

namespace SistemaTurnos.Dal.Repository.Interface
{
    public class MedicoRepository : Repository<Medico>, IMedicoRepository
    {
        public MedicoRepository(DataContext context) : base(context)
        {

        }

        Task<List<Paciente>> IMedicoRepository.GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
