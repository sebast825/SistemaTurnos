using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata;
using SistemaTurnos.Dal.Entities;
using SistemaTurnos.Dto.DisponibilidadMedico;
using SistemaTurnos.Dto.Medico;
using SistemaTurnos.Service;
using SistemaTurnos.Service.Interface;

namespace SistemaTurnos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DisponibilidadMedicosController : ControllerBase
    {
        private readonly IDisponibilidadMedicoService _disponibilidadMedicoService;
        private readonly IJwtService _jwtService;

        public DisponibilidadMedicosController(IDisponibilidadMedicoService disponibilidadMedicoService, IJwtService jwtService)
        {
            _disponibilidadMedicoService = disponibilidadMedicoService;
            _jwtService = jwtService;
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
        
        [HttpPost()]
        public async Task<ActionResult<bool>> Create (DisponibilidadMedicoCreateRequestDTO dto)
        {
           // _jwtService.isAdmin();
            var rsta = await _disponibilidadMedicoService.Create(dto);
            return rsta != null ? Ok(rsta) : BadRequest(rsta);
        }
        [HttpPut]
        public async Task<ActionResult<bool>> Update(DisponibilidadMedicoUpdateeRequestDTO dto)
        {
           // _jwtService.isAdmin();
            var rsta = await _disponibilidadMedicoService.Update(dto);
            return rsta != null ? Ok(rsta) : BadRequest(rsta);
        }

    }
}
