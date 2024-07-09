using SistemaTurnos.Dal.Entities;
using SistemaTurnos.Dto.Turno;

namespace SistemaTurnos.Service.Interface
{
    public interface ITurnoService
    {
        Task<List<TurnoResponseDTO>> GetAll();
        Task<List<TurnoResponseDTO>> FilterByDoctor(int id);
        Task<List<TurnoResponseDTO>> FilterByPaciente(int id);
        Task<List<TurnoResponseDTO>> FilterByDoctorProgramedToday(int id);
        Task<List<TurnoResponseDTO>> FilterByPacienteProgramed(int id);
    }
}
