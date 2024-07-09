using Microsoft.AspNetCore.Mvc;
using SistemaTurnos.Dto.Turno;
using SistemaTurnos.Service.Interface;

namespace SistemaTurnos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TurnoController : Controller
    {
        ITurnoService _turnoService;
        public TurnoController(ITurnoService turnoService) {
            _turnoService = turnoService;

        }
        [HttpGet("GetAll")]
        public async Task<List<TurnoResponseDTO>> GetAll()
        {
            var rsta = await _turnoService.GetAll();
            return rsta;
        }
    }
}
