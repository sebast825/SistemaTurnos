using Microsoft.EntityFrameworkCore;
using SistemaTurnos.Dal.Data;
using SistemaTurnos.Dal.Entities;
using SistemaTurnos.Dal.Repository.Interface;
using SistemaTurnos.Dto.Paciente;

namespace SistemaTurnos.Dal.Repository
{
    public class PacienteRepository : Repository<Paciente> ,IPacienteRepository
    {
        public PacienteRepository(DataContext context) : base(context)
        {
        }
        public async Task<List<Paciente>> GetAll()
        {
            var personas = await _context.Personas.Include(v => v.Sexo).ToListAsync();

            // Convertir List<Persona> a List<Paciente> si es necesario
            // Esto asume que Paciente es una subclase de Persona
            // Si quieres devolver específicamente Pacientes, puedes filtrar aquí
            var pacientes = personas.OfType<Paciente>().ToList();

            return pacientes;

        }
    }
}
