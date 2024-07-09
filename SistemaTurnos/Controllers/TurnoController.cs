using Microsoft.AspNetCore.Mvc;
using SistemaTurnos.Dto.Turno;
using SistemaTurnos.Service.Interface;

namespace SistemaTurnos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TurnoController : Controller
    {
        ITurnoService _turnoService;
        public TurnoController(ITurnoService turnoService) {
            _turnoService = turnoService;

        }
        [HttpGet("GetAll")]
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
        public async Task<List<TurnoResponseDTO>> FilterByPaciente(int id)
        {
            var rsta = await _turnoService.FilterByPaciente(id);
            return rsta;
        }
        [HttpGet("FilterByDateTime")]
        public async Task<List<TurnoResponseDTO>> FilterByDateTime(DateTime dt, int? idDoctor)
        {
            var rsta = await _turnoService.FilterByDateTime(dt,idDoctor);
            return rsta;
        }
        
    }
}
