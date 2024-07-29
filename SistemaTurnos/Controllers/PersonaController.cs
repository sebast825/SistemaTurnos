using Microsoft.AspNetCore.Mvc;
using SistemaTurnos.Dto.Persona;
using SistemaTurnos.Service.Interface;

namespace SistemaTurnos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonaController : ControllerBase
    {
        private readonly IPersonaService _personaService;
       public PersonaController(IPersonaService personaService) {
            _personaService = personaService;
        }

        [HttpPatch("ActualizarEstado")]

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

        [HttpPatch("ActualizarPersona")]

        public async Task<ActionResult<PersonaResponseDTO>> ActualizarPersona(int id, PersonaUpdateRequestDTO dto)
        {
            var rsta = await _personaService.ActualizarPersona(id, dto);

            return rsta;
        }

    }
}
