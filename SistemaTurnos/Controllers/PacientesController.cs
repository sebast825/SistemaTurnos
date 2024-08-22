using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SistemaTurnos.Authorization;
using SistemaTurnos.Common;
using SistemaTurnos.Dto.Paciente;
using SistemaTurnos.Service.Interface;

namespace SistemaTurnos.Controllers
{
    [Route("api/[controller]")]
    [Authorize]

    [ApiController]
    public class PacientesController : ControllerBase
    {
        private readonly IPacienteService _pacienteService;
        private readonly IJwtService _jwtService;
        public PacientesController(IPacienteService pacienteService, IJwtService jwtService) {
            _pacienteService = pacienteService;
            _jwtService = jwtService;
        }

        [HttpGet]
        [AllowAnonymous]
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
        [HttpGet("{id}")]
        public async Task<ActionResult<bool>> GetById(int id)
        {
           
            _jwtService.PacienteMatchIdOrAdministrativo(id);
        
            var rsta = await _pacienteService.GetById(id);
            return rsta != null ? Ok(rsta) : BadRequest(rsta);
           
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<bool>> Update(int id, PacienteUpdateRequestDTO dto )
        {

            _jwtService.PacienteMatchIdOrAdministrativo(id);

            var rsta = await _pacienteService.GetById(id);
            return rsta != null ? Ok(rsta) : BadRequest(rsta);

        }
    }
}
