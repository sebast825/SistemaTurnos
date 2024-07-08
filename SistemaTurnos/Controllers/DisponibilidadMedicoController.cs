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
            var rsta = await _disponibilidadMedicoService.GetAll();
            return rsta;
        }
        [HttpGet("GetByMedico")]
        public async Task<List<DisponibilidadMedicoResponseDTO>> GetByMedico(int idMedico)
        {
            var rsta = await _disponibilidadMedicoService.GetByMedico(idMedico);
            return rsta;
        }

        [HttpGet("FilterByEspecialidad")]
        public async Task<List<DisponibilidadMedicoResponseDTO>> FilterByEspecialidad(int idEspecialidad)
        {
            var rsta = await _disponibilidadMedicoService.FilterByEspecialidad(idEspecialidad);
            return rsta;
        }

    }
}
