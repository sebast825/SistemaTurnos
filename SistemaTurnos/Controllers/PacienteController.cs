using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using RouteAttribute = Microsoft.AspNetCore.Components.RouteAttribute;
using SistemaTurnos.Dto.Paciente;
using SistemaTurnos.Service.Interface;

namespace SistemaTurnos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacienteController : ControllerBase
    {
        private readonly IPacienteService _pacienteService;
        public PacienteController(IPacienteService pacienteService) {
            _pacienteService = pacienteService;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<PacienteResponseDTO>> GetAll()
        {
            var paciente =  await _pacienteService.GetAll();
            return Ok(paciente);
        }

        [HttpPost("Create")]

        public async Task<ActionResult<bool>> Create ( PacienteCreateRequestDTO paciente)
        {
            var rsta = await _pacienteService.Create(paciente);
          
            return rsta != null ? Ok(rsta) : BadRequest(rsta);

        }
    }
}
