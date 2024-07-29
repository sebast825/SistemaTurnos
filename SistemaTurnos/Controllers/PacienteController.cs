using Microsoft.AspNetCore.Mvc;
using SistemaTurnos.Dto.Paciente;
using SistemaTurnos.Service.Interface;

namespace SistemaTurnos.Controllers
{
    [Route("api/[controller]")]

    [ApiController]
    public class PacienteController : ControllerBase
    {
        private readonly IPacienteService _pacienteService;
        private readonly IJwtService _jwtService;
        public PacienteController(IPacienteService pacienteService, IJwtService jwtService) {
            _pacienteService = pacienteService;
            _jwtService = jwtService;
        }

        [HttpGet]
        public async Task<ActionResult<PacienteResponseDTO>> GetAll()
        {
            var paciente =  await _pacienteService.GetAll();
            return Ok(paciente);
        }

        [HttpPost]

        public async Task<ActionResult<bool>> Create ( PacienteCreateRequestDTO paciente)
        {
            var rsta = await _pacienteService.Create(paciente);
          
            return rsta != null ? Ok(rsta) : BadRequest(rsta);

        }
        [HttpPost("{id}")]
        public async Task<ActionResult<bool>> GetById(int id)
        {
            //valida que el id coincida con su jwt
            //var token = HttpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            bool jwtMatchiD = _jwtService.UserMatchRequestId(id);

            if (jwtMatchiD)
            {
                var rsta = await _pacienteService.GetById(id);

                return rsta != null ? Ok(rsta) : BadRequest(rsta);
            }
            else
            {
                return BadRequest("has no access");
            }
           

        }
    }
}
