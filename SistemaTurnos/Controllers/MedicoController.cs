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
  
    public class MedicoController : ControllerBase
    {
        private readonly IMedicoService _medicoService;
        private readonly IJwtService _jwtService;

        public MedicoController(IMedicoService medicicoService, IJwtService jwtService)
        {
            _medicoService = medicicoService;
            _jwtService = jwtService;
        }

        [HttpPost("Create")]

        [RequirePermission(Permission.CreatePersona)]
        public async Task<ActionResult<bool>> Create (MedicoCreateRequestDTO dto){

            var rsta = await _medicoService.Create(dto);
            return rsta != null ? Ok(rsta) : BadRequest(rsta);
        }
        [HttpGet("GetAll")]
        public async Task<List<MedicoResponseDTO>> GetAll()
        {
            var rsta = await _medicoService.GetAll();
            return rsta;
        }
        [HttpGet("FilterByEspecialidad")]

        public async Task<List<MedicoResponseDTO>> FilterByEspecialidad(int id)
        {
            //_jwtService.UserMatchType(Role.Paciente);
            var rsta = await _medicoService.FilterByEspecialidad(id);
            return rsta;
        }
    }
}
