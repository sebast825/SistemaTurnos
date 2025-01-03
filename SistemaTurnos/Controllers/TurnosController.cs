using Microsoft.AspNetCore.Mvc;
using SistemaTurnos.Dto.Turno;
using SistemaTurnos.Service.Interface;

namespace SistemaTurnos.Controllers
{
    [Route("")]
    [ApiController]
    //[Authorize]
    public class TurnosController : Controller
    {
        private readonly ITurnoService _turnoService;
        private readonly IJwtService _jwtService;

        public TurnosController(ITurnoService turnoService, IJwtService jwtService)
        {
            _turnoService = turnoService;
            _jwtService = jwtService;

        }

        [HttpGet("api/turnos")]
        public async Task<List<TurnoResponseDTO>> GetAll()
        {
            _jwtService.isNotPaciente();
            var rsta = await _turnoService.GetAll();
            return rsta;
        }
        [HttpGet("FilterByEstadoTurno")]
        public async Task<List<TurnoResponseDTO>> FilterByEstadoTurno(EstadoTurno estado)
        {
            _jwtService.isNotPaciente();

            var rsta = await _turnoService.FilterByEstadoTurno(estado);
            return rsta;
        }

        [HttpGet("GetEstadosTurno")]
        public ActionResult<List<string>> GetEstadosTurno()
        {
            var estados = Enum.GetNames(typeof(EstadoTurno)).ToList();
            return Ok(estados);
        }


        [HttpGet("api/turnos/FilterByDoctor")]
        public async Task<List<TurnoResponseDTO>> FilterByDoctor(int id)
        {
            _jwtService.isNotPaciente();

            var rsta = await _turnoService.FilterByDoctor(id);
            return rsta;
        }
        [HttpGet("api/pacientes/{id}/turnos")]
        public async Task<ActionResult<List<TurnoResponseDTO>>> FilterByPaciente(int id)
        {
            _jwtService.PacienteMatchIdOrOthers(id);
            var rsta = await _turnoService.FilterByPaciente(id);
            return rsta;


        }
        [HttpGet("FilterByDateTime")]
        public async Task<List<TurnoResponseDTO>> FilterByDateTime(DateTime dt, int? idDoctor)
        {
            _jwtService.isNotPaciente();
            var rsta = await _turnoService.FilterByDateTime(dt, idDoctor);
            return rsta;
        }

        [HttpGet("/medico/{idDoctor}/turnosHoy/{dt}")]
        public async Task<List<TurnoResponseDTO>> DoctorTurnosByDate(DateTime dt, int idDoctor)
        {

            _jwtService.isNotPaciente();
            var rsta = await _turnoService.DoctorTurnosByDate(dt, idDoctor);
            return rsta;
        }
        [HttpPost("api/turnos/")]
        public async Task<ActionResult<TurnoResponseDTO>> Create(TurnoCreateRequestDTO dto)
        {
            _jwtService.PacienteMatchIdOrAdministrativo(dto.PacienteId);
            var rsta = await _turnoService.Create(dto);
            return rsta;
        }

        [HttpGet("api/medicos/{medicoId}/turnosdisponible")]
        public async Task<List<TurnoHorarioDisponibleResponseDTO>> TurnosDisponiblesByMedico(int medicoId)
        {
            var rsta = await _turnoService.TurnosDisponiblesByMedico(medicoId);
            return rsta;
        }
        [HttpGet("api/especialidad/{especialidad}/turnosdisponible")]

        public async Task<List<TurnoHorarioDisponibleResponseDTO>> TurnosDisponiblesByEspecialidad(string especialidad)
        {
            var rsta = await _turnoService.TurnosDisponiblesByEspecialidad(especialidad);
            return rsta;
        }
        [HttpPatch("api/pacientes/turnos/{idTurno}/cancelar")]

        public async Task<ActionResult<TurnoResponseDTO>> CancelarTurno(int idTurno)
        {   
            var rsta = await _turnoService.CancelarTurno(idTurno);
            return rsta;
        }
        [HttpPatch("api/pacientes/turnos/{idTurno}/{estadoTurno}")]

        public async Task<TurnoResponseDTO> ActualizarEstadoTurno(int idTurno, EstadoTurno estadoTurno)
        {
            _jwtService.isNotPaciente();
            var rsta = await _turnoService.ActualizarEstadoTurno(idTurno, estadoTurno);
            return rsta;
        }

    }
}
