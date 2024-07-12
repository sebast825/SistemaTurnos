using Microsoft.AspNetCore.Mvc;
using SistemaTurnos.Dto.Administrativo;
using SistemaTurnos.Dto.Medico;
using SistemaTurnos.Service;
using SistemaTurnos.Service.Interface;

namespace SistemaTurnos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdministrativoController : ControllerBase
    {
        private readonly IAdministrativoService _administrativoService;
      public AdministrativoController(IAdministrativoService administrativoService) {

            _administrativoService = administrativoService;

        }


        [HttpPost("Create")]
        public async Task<ActionResult<bool>> Create(AdministrativoRequestCreateDTO dto)
        {
            var rsta = await _administrativoService.Create(dto);
            return rsta != null ? Ok(rsta) : BadRequest(rsta);
        }
    }
}
