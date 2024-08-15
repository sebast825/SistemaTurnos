using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SistemaTurnos.Common;
using SistemaTurnos.Dto.DisponibilidadMedico;
using SistemaTurnos.Dto.Turno;
using SistemaTurnos.Service;
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

        public TurnosController(ITurnoService turnoService, IJwtService jwtService) {
            _turnoService = turnoService;
            _jwtService = jwtService;

        }
       
        [HttpGet("api/turnos")]
        public async Task<List<TurnoResponseDTO>> GetAll()
        {
            //_jwtService.isNotPaciente();
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
        

        [HttpGet("FilterByDoctor")]
        public async Task<List<TurnoResponseDTO>> FilterByDoctor(int id)
        {
            _jwtService.isNotPaciente();

            var rsta = await _turnoService.FilterByDoctor(id);
            return rsta;
        }
        [HttpGet("api/pacientes/{id}/turnos")]
        public async Task<ActionResult<List<TurnoResponseDTO>>> FilterByPaciente(int id)
        {
           
            try
            {
                 _jwtService.PacienteMatchIdOrOthers(id);           
            }
            catch(Exception err)
            {
                return Unauthorized(new { Message = ErrorMessages.NoAccess });
            }

            var rsta = await _turnoService.FilterByPaciente(id);
            if (rsta != null)
            {
                return Ok(rsta);
            }
            else
            {
                return NotFound();
            }


        }
        [HttpGet("FilterByDateTime")]
        public async Task<List<TurnoResponseDTO>> FilterByDateTime(DateTime dt, int? idDoctor)
        {
            _jwtService.isNotPaciente();
            var rsta = await _turnoService.FilterByDateTime(dt,idDoctor);
            return rsta;
        }
        [HttpPost("api/turnos/")]
        public async Task<ActionResult<TurnoResponseDTO>> Create(TurnoCreateRequestDTO dto)
        {
           
            _jwtService.PacienteMatchIdOrAdministrativo(dto.PacienteId);
            var rsta = await _turnoService.Create(dto);
            return rsta;
        }

        [HttpGet("ObtenerHorariosDisponibles")]
        public async Task<List<HorarioMedicoLibreResponseDTO>> ObtenerHorariosDisponibles(int idMedico)
        {
            var rsta = await _turnoService.ObtenerHorariosDisponibles(idMedico);
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
        [HttpPatch("api/pacientes/{idPaciente}/turnos/{idTurno}/cancelar")]

        public async Task<TurnoResponseDTO> CancelarTurno(int idTurno, int idPaciente)
        {
            var rsta = await _turnoService.CancelarTurno(idTurno);
            return rsta;
        }

    }
}
