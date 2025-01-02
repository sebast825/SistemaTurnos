using SistemaTurnos.Dal.Entities;
using SistemaTurnos.Dto.DisponibilidadMedico;
using SistemaTurnos.Dto.Turno;

namespace SistemaTurnos.Service.Interface
{
    public interface ITurnoService
    {
        Task<List<TurnoResponseDTO>> GetAll();
        Task<List<TurnoResponseDTO>> FilterByEstadoTurno(EstadoTurno estado);
        Task<List<TurnoResponseDTO>> FilterByDoctor(int id, EstadoTurno ? estadoTurno = null);
        Task<List<TurnoResponseDTO>> FilterByPaciente(int id);
        Task<List<TurnoResponseDTO>> FilterByDoctorProgramedToday(int id);
        Task<TurnoResponseDTO> Create(TurnoCreateRequestDTO dto);
        Task<List<TurnoResponseDTO>> FilterByDateTime(DateTime fecha, int? medicoId);
        Task<bool> MedicoIsAviable(TurnoCreateRequestDTO dto);
        Task<List<HorarioMedicoLibreResponseDTO>> ObtenerHorariosDisponibles(int medicoId);

        Task<List<TurnoHorarioDisponibleResponseDTO>> TurnosDisponiblesByMedico(int medicoId);
        Task<List<TurnoHorarioDisponibleResponseDTO>> TurnosDisponiblesByEspecialidad(string especialidad);

        Task<TurnoResponseDTO> CancelarTurno(int idTurno);
        Task<TurnoResponseDTO> ActualizarEstadoTurno(int idTurno, EstadoTurno estadoTurno);

        Task<List<TurnoResponseDTO>> DoctorTurnosByDate(DateTime dt, int idMedico);

        public bool suma(int a, int b);
    }
}

