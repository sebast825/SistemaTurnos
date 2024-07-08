using SistemaTurnos.Dal.Data;
using SistemaTurnos.Dal.Entities;
using SistemaTurnos.Dal.Repository.Interface;

namespace SistemaTurnos.Dal.Repository
{
    public class DiaSemanaRepository : Repository<DiaSemana>, IDiaSemanaRepository
    {
        public DiaSemanaRepository(DataContext context) : base(context)
        {
        }
    }
}
