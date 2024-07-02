using SistemaTurnos.Dto.Paciente;
using SistemaTurnos.Service.Interface;

namespace SistemaTurnos.Service
{
    public class PacienteService : IPacienteService
    {
        public async Task<List<PacienteResponseDTO>> GetAll()
        {
            await Task.CompletedTask;
            Console.WriteLine("service");
            var paciente = new List<PacienteResponseDTO>
            {
                   new PacienteResponseDTO
                {
                    // Inicializa las propiedades del DTO según sea necesario
                }
            };
            return paciente;
        }
    }
}
