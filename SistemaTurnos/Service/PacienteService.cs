using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using SistemaTurnos.Common;
using SistemaTurnos.Dal;
using SistemaTurnos.Dal.Entities;
using SistemaTurnos.Dto.Paciente;
using SistemaTurnos.Dto.Persona;
using SistemaTurnos.Service.Interface;
using System.Security.Cryptography;

namespace SistemaTurnos.Service
{
    public class PacienteService : IPacienteService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public PacienteService(IUnitOfWork unitOfWork, IMapper mapper) { 
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<int> Create(PacienteCreateRequestDTO dto)
        {
        
            var entity = _mapper.Map<Paciente>(dto);
            //entity.ValidarAtributos();

            await _unitOfWork.PacienteRepository.Add(entity);
            await _unitOfWork.Save();
            return entity.Id;
        }

        public async Task<List<PacienteResponseDTO>> GetAll()
        {
            var pacientes = await _unitOfWork.PacienteRepository.GetAll();
            var rsta = _mapper.Map<List<PacienteResponseDTO>>(pacientes);
         
            return rsta;
        }
        public async Task<PacienteResponseDTO> GetById(int id)
        {
            var paciente = await _unitOfWork.PacienteRepository.GetById(id);
            var rsta = _mapper.Map<PacienteResponseDTO>(paciente);

            return rsta;
        }

        public async Task<PacienteResponseDTO> Update(int id, PacienteUpdateRequestDTO dto)
        {
            var paciente = await _unitOfWork.PacienteRepository.GetById(id);

            if(paciente != null)
            {
                paciente.NombreEmergencia = dto.NombreEmergencia;
                paciente.TelefonoEmergencia = dto.TelefonoEmergencia;
                await _unitOfWork.Save();
                var pacienteUpdated = await _unitOfWork.PacienteRepository.GetById(id);
                var rsta = _mapper.Map<PacienteResponseDTO>(pacienteUpdated);
                return rsta;
            }
            throw new Exception(ErrorMessages.PacienteNotFound);
        }
        /*
private List<PacienteResponseDTO> EntitiesToCamionResponseDtos(IEnumerable<Paciente> pacientes)
{
   var responseDtos = new List<PacienteResponseDTO>();
   foreach (Paciente paciente in pacientes)
   {
       responseDtos.Add(EntityToPacienteResponseDto(paciente));
   }
   return responseDtos;
}
private PacienteResponseDTO EntityToPacienteResponseDto(Paciente paciente)
{
   var responseDto = new PacienteResponseDTO
   {
       Nombre = paciente.Nombre,
       Apellido = paciente.Apellido,
       FechaNacimiento = paciente.FechaNacimiento,
       Telefono = paciente.Telefono,
       NumeroDocumento = paciente.NumeroDocumento,
       Email = paciente.Email,
       //Sexo = paciente.Sexo,
       TelefonoEmergencia = paciente.TelefonoEmergencia,
       NombreEmergencia = paciente.NombreEmergencia

   };
   return responseDto;
}*/
    }
}
