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

        public async Task<PersonaResponseDTO> ActualizarEstado(int dni, int estado)
        {
            var rsta = await _personaService.ActualizarEstado(dni, estado);

            return rsta;
        }

        [HttpPatch("ActualizarEstadoEliminar")]

        public async Task<PersonaResponseDTO> ActualizarEstadoEliminar(int dni)
        {
            var rsta = await _personaService.ActualizarEstadoEliminar(dni);
            return rsta;
        }

    }
}
