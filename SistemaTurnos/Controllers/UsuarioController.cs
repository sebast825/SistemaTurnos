using Microsoft.AspNetCore.Mvc;
using SistemaTurnos.Common;
using SistemaTurnos.Dal;
using SistemaTurnos.Dto.Paciente;
using SistemaTurnos.Dto.User;
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
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPacienteService _pacienteService;
        private readonly IJwtService _jwtService;

        public UsuarioController(IUsuarioService usuarioService, IPacienteService PacienteService, IUnitOfWork unitOfWork, IJwtService jwtService)
        {
            _usuarioService = usuarioService;
            _pacienteService = PacienteService;
            _unitOfWork = unitOfWork;
            _jwtService = jwtService;
        }


        [HttpPatch("/api/usuario/{id}/estado/{estado}")]

        public async Task<ActionResult<PacienteResponseDTO>> ActualizarUsuario(int id, EstadoUsuario estado)
        {

            _jwtService.PacienteMatchIdOrAdministrativo(id);
            var rsta = await _usuarioService.UpdateEstado(id, estado);

            return Ok(rsta);

        }
        [HttpPost("/api/usuario/paciente")]
        public async Task<ActionResult> CreatePaciente([FromBody] UserAndPatientCreateRequestDto data)
        {
            await using var transaction = await _unitOfWork.BeginTransactionAsync();
            int pacienteId = await _pacienteService.Create(data.Paciente);
            await _usuarioService.CreatePaciente(data.Usuario, pacienteId);
            await transaction.CommitAsync();
            return Ok(new { Message = "Usuario y paciente creados correctamente" });

        }

        [HttpPost("/api/usuario/requestUpdatePassword")]
        async public Task<ActionResult> StartRecoveryPassword([FromBody] RecoveryEmailRequestDo dto)
        {
            //valida el formato del dto
            if (ModelState.IsValid)
            {
                await _usuarioService.StartRecoveryPassword(dto);
                return Ok();
            }
            else
            {
                return BadRequest("El email no es valido");
            }

        }
        [HttpPost("/api/usuario/updatePassword")]

        async public Task<ActionResult> RecoveryPassword([FromBody] NuevaClaveRequestDTO dto)
        {
            //valida el formato del dto
            if (ModelState.IsValid)
            {
                await _usuarioService.ActualizarClave(dto);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }



    }
}
