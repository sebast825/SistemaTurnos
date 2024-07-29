using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using SistemaTurnos.Common;
using SistemaTurnos.Dal;
using SistemaTurnos.Dal.Entities;
using SistemaTurnos.Dto.Paciente;
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

        public async Task<PacienteResponseDTO> Create(PacienteCreateRequestDTO dto)
        {
            var paciente = await _unitOfWork.PersonaRepository.GetByDni(dto.NumeroDocumento);
            if(paciente == null || paciente.EstadoPersona == EstadoPersona.Inactivo)
            {
                var entity = _mapper.Map<Paciente>(dto);
                await _unitOfWork.PacienteRepository.Add(entity);
                await _unitOfWork.Save();
                return _mapper.Map<PacienteResponseDTO>(entity);
       
            }
            throw new Exception("ya existe");

        }

        public async Task<List<PacienteResponseDTO>> GetAll()
        {
            var pacientes = await _unitOfWork.PacienteRepository.GetAll();
            var rsta = _mapper.Map<List<PacienteResponseDTO>>(pacientes);
         
            return rsta;
        }
        public async Task<List<PacienteResponseDTO>> GetById(int id)
        {
            var paciente = await _unitOfWork.PacienteRepository.GetById(id);
            var rsta = _mapper.Map<List<PacienteResponseDTO>>(paciente);

            return rsta;
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
