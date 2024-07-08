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
          
            var asd = await _unitOfWork.DisponibilidadMedicoRepository.GetAll();

           
            var map = _mapper.Map<List<DisponibilidadMedicoResponseDTO>>(asd);
            return map;

        }

        public Task<List<DisponibilidadMedicoResponseDTO>> GetByMedico(int idMedico)
        {
            throw new NotImplementedException();
        }
       

    }
}
