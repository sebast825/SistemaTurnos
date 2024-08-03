using Microsoft.AspNetCore.Diagnostics;
using SistemaTurnos.Dal.Data;
using SistemaTurnos.Dal.Repository;
using SistemaTurnos.Dal.Repository.Interface;
using SistemaTurnos.Service.Interface;

namespace SistemaTurnos.Dal
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;
        public IPersonaRepository PersonaRepository { get; }

        public IPacienteRepository PacienteRepository { get; }
        public IMedicoRepository MedicoRepository { get; }
        public IDisponibilidadMedicoRepository DisponibilidadMedicoRepository { get; }
        public IDiaSemanaRepository DiaSemanaRepository { get; }
        public ITurnoRepository TurnoRepository { get; }
        public IAdministrativoRepository AdministrativoRepository { get; }
        public IUsuarioRepository UsuarioRepository { get; }
        public UnitOfWork(DataContext context, IPacienteRepository pacienteRepository, IPersonaRepository personaRepository,
            IMedicoRepository medicoRepository,
                      IDisponibilidadMedicoRepository disponibilidadMedicoRepository,
                      IDiaSemanaRepository diaSemanaRepository,
                      ITurnoRepository turnoRepository,
                      IAdministrativoRepository administrativoRepository,
                      IUsuarioRepository usuarioRepository

            )
        {
            _context = context;
            PacienteRepository = pacienteRepository;
            PersonaRepository = personaRepository;
            MedicoRepository = medicoRepository;
            DisponibilidadMedicoRepository = disponibilidadMedicoRepository;
            DiaSemanaRepository = diaSemanaRepository;
            TurnoRepository = turnoRepository;
            AdministrativoRepository = administrativoRepository;
            UsuarioRepository = usuarioRepository;
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
