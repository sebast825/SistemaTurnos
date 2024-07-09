using SistemaTurnos.Dal.Entities;


namespace SistemaTurnos.Dal.Repository.Interface
{
    public interface ITurnoRepository : IRepository<Turno>
    {
        new Task<List<Turno>>  GetAll();
        Task<List<Turno>> FilterByDoctor(int id);
        Task<List<Turno>> FilterByPaciente(int id);
        Task<List<Turno>> FilterByEstadoTurno(EstadoTurno estado);

    }
}
