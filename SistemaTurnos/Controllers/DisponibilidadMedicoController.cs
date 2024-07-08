using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata;
using SistemaTurnos.Dal.Entities;
using SistemaTurnos.Dto.DisponibilidadMedico;
using SistemaTurnos.Dto.Medico;
using SistemaTurnos.Service.Interface;

namespace SistemaTurnos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DisponibilidadMedicoController : ControllerBase
    {
        private readonly IDisponibilidadMedicoService _disponibilidadMedicoService;

        public DisponibilidadMedicoController(IDisponibilidadMedicoService disponibilidadMedicoService)
        {
            _disponibilidadMedicoService = disponibilidadMedicoService;
        }

        [HttpGet("GetAll")]
        public async Task<List<DisponibilidadMedicoResponseDTO>> GetAll()
        {
            Console.WriteLine("estaoas??");
            var asd = await _disponibilidadMedicoService.GetAll();
            return asd;
        }

    }
}
