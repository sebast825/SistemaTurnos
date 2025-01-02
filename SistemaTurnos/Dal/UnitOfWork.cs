using Microsoft.AspNetCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Storage;
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
        public IEspecialidadRepository EspecialidadRepository{ get; }

        public UnitOfWork(DataContext context, IPacienteRepository pacienteRepository, IPersonaRepository personaRepository,
            IMedicoRepository medicoRepository,
                      IDisponibilidadMedicoRepository disponibilidadMedicoRepository,
                      IDiaSemanaRepository diaSemanaRepository,
                      ITurnoRepository turnoRepository,
                      IAdministrativoRepository administrativoRepository,
                      IUsuarioRepository usuarioRepository,
                      IEspecialidadRepository especialidadRepository

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
            EspecialidadRepository = especialidadRepository;
        }

        public async Task<int> Save()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context?.Dispose();
        }

        public async Task<IDbContextTransaction> BeginTransactionAsync()
        {
            return await _context.Database.BeginTransactionAsync();
        }

    }
}
