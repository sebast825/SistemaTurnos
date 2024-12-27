using Microsoft.AspNetCore.Authorization;
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
        public UsuarioController(IUsuarioService usuarioService, IPacienteService PacienteService, IUnitOfWork unitOfWork)
        {
            _usuarioService = usuarioService;
            _pacienteService = PacienteService;
            _unitOfWork = unitOfWork;
        }


        [HttpPatch("/api/usuario/{id}/estado/{estado}")]

        public async Task<ActionResult<PacienteResponseDTO>> ActualizarUsuario(int id, EstadoUsuario estado)
        {

            //_jwtService.PacienteMatchIdOrAdministrativo(id);
           var rsta =  await _usuarioService.UpdateEstado(id, estado);

            return Ok(rsta);

        }
        [HttpPost("/api/usuario/paciente")]
        public async Task<ActionResult> CreatePaciente([FromBody] UserAndPatientCreateRequestDto data)
        {   
            
            try
            {
               // await using var transaction = await _unitOfWork.BeginTransactionAsync();

                int pacienteId = await _pacienteService.Create(data.Paciente);

                if (data != null) {
                    await _usuarioService.CreatePaciente(data.Usuario, pacienteId);
                }

                //await transaction.CommitAsync();
                return Ok(new { Message = "Usuario y paciente creados correctamente" });

            }
            catch (Exception ex)
            {                
                return StatusCode(500, new { Message = ex });
            }
        }



    }
}
