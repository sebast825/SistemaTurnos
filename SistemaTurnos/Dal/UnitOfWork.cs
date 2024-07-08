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
        public IEstadoUsuarioRepository EstadoUsuarioRepository { get; }
        public IMedicoRepository MedicoRepository { get; }
        public IDisponibilidadMedicoRepository DisponibilidadMedicoRepository { get; }
        public IDiaSemanaRepository DiaSemanaRepository { get; }
        public UnitOfWork(DataContext context, IPacienteRepository pacienteRepository, IPersonaRepository personaRepository,
            IEstadoUsuarioRepository estadoUsuarioRepository,
            IMedicoRepository medicoRepository,
                      IDisponibilidadMedicoRepository disponibilidadMedicoRepository,
                      IDiaSemanaRepository diaSemanaRepository

            )
        {
            _context = context;
            PacienteRepository = pacienteRepository;
            PersonaRepository = personaRepository;
            EstadoUsuarioRepository = estadoUsuarioRepository;
            MedicoRepository = medicoRepository;
            DisponibilidadMedicoRepository = disponibilidadMedicoRepository;
            DiaSemanaRepository = diaSemanaRepository;
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
