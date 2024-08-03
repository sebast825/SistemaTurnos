using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SistemaTurnos.Authorization;
using SistemaTurnos.Common;
using SistemaTurnos.Dto.Administrativo;
using SistemaTurnos.Dto.Medico;
using SistemaTurnos.Service;
using SistemaTurnos.Service.Interface;

namespace SistemaTurnos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AdministrativosController : ControllerBase
    {
        private readonly IAdministrativoService _administrativoService;
        private readonly IJwtService _jwtService;

        public AdministrativosController(IAdministrativoService administrativoService, IJwtService jwtService)
        {

            _administrativoService = administrativoService;
            _jwtService = jwtService;
        }


        [HttpPost("Create")]
        public async Task<ActionResult<bool>> Create(AdministrativoRequestCreateDTO dto)
        {
            _jwtService.isAdmin();
            var rsta = await _administrativoService.Create(dto);
            return rsta != null ? Ok(rsta) : BadRequest(rsta);
        }
    }
}
