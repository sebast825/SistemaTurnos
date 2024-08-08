using SistemaTurnos.Dal.Entities;


namespace SistemaTurnos.Dal.Repository.Interface
{
    public interface ITurnoRepository : IRepository<Turno>
    {
        new Task<List<Turno>>  GetAll();
        Task<List<Turno>> FilterByDoctor(int id, EstadoTurno? estadoTurno = null);
        Task<List<Turno>> FilterByPaciente(int id);
        Task<List<Turno>> FilterByEstadoTurno(EstadoTurno estado);
        Task<List<Turno>> FilterByDateTime (DateTime dt, int? medicoId);
        Task<List<Turno>> FilterByDate(DateTime dt, int? medicoId = null);
        Task<Turno> UpdateEstado(int id, EstadoTurno estadoTurno);
    }
}
