using SistemaTurnos.Dal.Repository.Interface;
using SistemaTurnos.Service.Interface;

namespace SistemaTurnos.Dal
{
    public interface IUnitOfWork : IDisposable
    {
        IPersonaRepository PersonaRepository { get; }
        IPacienteRepository PacienteRepository { get; }
        IMedicoRepository MedicoRepository { get; }
        IDisponibilidadMedicoRepository DisponibilidadMedicoRepository { get; }
        IDiaSemanaRepository DiaSemanaRepository { get; }
        ITurnoRepository TurnoRepository { get; }
        IAdministrativoRepository AdministrativoRepository { get; }

        IUsuarioRepository UsuarioRepository { get; }
        IEspecialidadRepository EspecialidadRepository { get; } 
        Task<int> Save();

    }
}
