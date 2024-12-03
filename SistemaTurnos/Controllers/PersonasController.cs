using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SistemaTurnos.Dto.Persona;
using SistemaTurnos.Service;
using SistemaTurnos.Service.Interface;

namespace SistemaTurnos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class PersonasController : ControllerBase
    {
        private readonly IPersonaService _personaService;
        private readonly IJwtService _jwtService;
        public PersonasController(IPersonaService personaService, IJwtService jwtService)
        {
            _personaService = personaService;
            _jwtService = jwtService;
        }

        //[HttpPatch("ActualizarEstado")]

        //public async Task<PersonaResponseDTO> ActualizarEstado(int id, int estado)
        //{
        //    var rsta = await _personaService.ActualizarEstado(id, estado);

        //    return rsta;
        //}

        //[HttpPatch("ActualizarEstadoEliminar")]

        //public async Task<PersonaResponseDTO> ActualizarEstadoEliminar(int id)
        //{
        //    var rsta = await _personaService.ActualizarEstadoEliminar(id);
        //    return rsta;
        //}
        [HttpGet("{id}")]
        public async Task<ActionResult<bool>> GetById(int id)
        {

            _jwtService.PacienteMatchIdOrAdministrativo(id);

            var rsta = await _personaService.GetById(id);
            return rsta != null ? Ok(rsta) : BadRequest(rsta);

        }
        [HttpPut("/api/personas/{id}")]

        public async Task<ActionResult<PersonaResponseDTO>> ActualizarPersona(int id, PersonaUpdateRequestDTO dto)
        {
            
            //_jwtService.PacienteMatchIdOrAdministrativo(id);
            var rsta = await _personaService.ActualizarPersona(id, dto);

            return rsta;
        }

    }
}
