using AutoMapper;
using Microsoft.AspNetCore.Server.IIS.Core;
using SistemaTurnos.Dal;
using SistemaTurnos.Dal.Entities;
using SistemaTurnos.Dto.DisponibilidadMedico;
using SistemaTurnos.Service.Interface;

namespace SistemaTurnos.Service
{
    public class DisponibilidadMedicoService : IDisponibilidadMedicoService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public DisponibilidadMedicoService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public Task<DisponibilidadMedicoResponseDTO> Create(DisponibilidadMedicoCreateRequestDTO dto)
        {
            throw new NotImplementedException();
        }

        public Task<List<DisponibilidadMedicoResponseDTO>> FilterByEspecialidad(int idEspecialidad)
        {
            throw new NotImplementedException();
        }

        public async Task<List<DisponibilidadMedicoResponseDTO>> GetAll()
        {
          
            var medicos = await _unitOfWork.DisponibilidadMedicoRepository.GetAll();

           
            var rsta = _mapper.Map<List<DisponibilidadMedicoResponseDTO>>(medicos);
            return rsta;

        }

        public async Task<List<DisponibilidadMedicoResponseDTO>> GetByMedico(int idMedico)
        {

            var medico = await _unitOfWork.DisponibilidadMedicoRepository.GetByMedico(idMedico);


            var rsta = _mapper.Map<List<DisponibilidadMedicoResponseDTO>>(medico);
            return rsta;
        }
       

    }
}
