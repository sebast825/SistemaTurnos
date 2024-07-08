using SistemaTurnos.Dal.Repository.Interface;
using SistemaTurnos.Service.Interface;

namespace SistemaTurnos.Dal
{
    public interface IUnitOfWork : IDisposable
    {
        IPersonaRepository PersonaRepository { get; }
        IPacienteRepository PacienteRepository { get; }
        IEstadoUsuarioRepository EstadoUsuarioRepository { get; }
        IMedicoRepository MedicoRepository { get; }
        IDisponibilidadMedicoRepository DisponibilidadMedicoRepository { get; }
        Task<int> Save();

    }
}
