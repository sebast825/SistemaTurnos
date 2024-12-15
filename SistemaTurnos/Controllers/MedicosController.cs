using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SistemaTurnos.Authorization;
using SistemaTurnos.Common;
using SistemaTurnos.Dto.Medico;
using SistemaTurnos.Service.Interface;

namespace SistemaTurnos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MedicosController : ControllerBase
    {
        private readonly IMedicoService _medicoService;
        private readonly IJwtService _jwtService;

        public MedicosController(IMedicoService medicicoService, IJwtService jwtService)
        {
            _medicoService = medicicoService;
            _jwtService = jwtService;
        }

        [HttpPost("Create")]

        public async Task<ActionResult<bool>> Create (MedicoCreateRequestDTO dto){
            _jwtService.isAdmin();
            var rsta = await _medicoService.Create(dto);
            return rsta != null ? Ok(rsta) : BadRequest(rsta);
        }
        [HttpGet]
        [AllowAnonymous]
        public async Task<List<MedicoResponseDTO>> GetAll()
        {
            var rsta = await _medicoService.GetAll();
            return rsta;
        }
        [HttpGet("FilterByEspecialidad")]
        [AllowAnonymous]
        public async Task<List<MedicoResponseDTO>> FilterByEspecialidad(int id)
        {
            //_jwtService.UserMatchType(Role.Paciente);
            var rsta = await _medicoService.FilterByEspecialidad(id);
            return rsta;
        }
        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<MedicoResponseDTO>> GetById(int id)
        {
            var rsta = await _medicoService.GetById(id);
            return Ok(rsta);
        }
    }
}
