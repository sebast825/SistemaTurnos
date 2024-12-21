using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SistemaTurnos.Common;
using SistemaTurnos.Dto.Persona;
using SistemaTurnos.Service;
using SistemaTurnos.Service.Interface;

namespace SistemaTurnos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   // [Authorize]
    public class UsuarioController : ControllerBase
    {

        private readonly IUsuarioService _usuarioService;
        public UsuarioController(IUsuarioService usuarioService) {
            _usuarioService = usuarioService;
        }


        [HttpPatch("/api/usuario/{id}/estado/{estado}")]

        public async Task<ActionResult<PersonaResponseDTO>> ActualizarUsuario(int id, EstadoUsuario estado)
        {

            //_jwtService.PacienteMatchIdOrAdministrativo(id);
           var rsta =  await _usuarioService.UpdateEstado(id, estado);

            return Ok(rsta);

        }


    }
}
