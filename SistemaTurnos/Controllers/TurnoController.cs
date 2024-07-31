using Microsoft.AspNetCore.Mvc;
using SistemaTurnos.Common;
using SistemaTurnos.Dto.Turno;
using SistemaTurnos.Service;
using SistemaTurnos.Service.Interface;

namespace SistemaTurnos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TurnoController : Controller
    {
        private readonly ITurnoService _turnoService;
        private readonly IJwtService _jwtService;

        public TurnoController(ITurnoService turnoService, IJwtService jwtService) {
            _turnoService = turnoService;
            _jwtService = jwtService;

        }
       
        [HttpGet]
        public async Task<List<TurnoResponseDTO>> GetAll()
        {
            var rsta = await _turnoService.GetAll();
            return rsta;
        }
        [HttpGet("FilterByEstadoTurno")]
        public async Task<List<TurnoResponseDTO>> FilterByEstadoTurno(EstadoTurno estado)
        {
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
            var rsta = await _turnoService.FilterByDoctor(id);
            return rsta;
        }
        [HttpGet("FilterByPaciente")]
        public async Task<ActionResult<List<TurnoResponseDTO>>> FilterByPaciente(int id)
        {
            bool idJwtMatch = _jwtService.UserMatchRequestId(id);
            if (idJwtMatch)
            {
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
            else
            {
                return Unauthorized(ErrorMessages.NoAccess);
            }

        }
        [HttpGet("FilterByDateTime")]
        public async Task<List<TurnoResponseDTO>> FilterByDateTime(DateTime dt, int? idDoctor)
        {
            var rsta = await _turnoService.FilterByDateTime(dt,idDoctor);
            return rsta;
        }
        [HttpPost]
        public async Task<TurnoResponseDTO> Create(TurnoCreateRequestDTO dto)
        {
            var rsta = await _turnoService.Create(dto);
            return rsta;
        }

    }
}
