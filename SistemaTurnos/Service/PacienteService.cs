﻿using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using SistemaTurnos.Dal;
using SistemaTurnos.Dal.Entities;
using SistemaTurnos.Dto.Paciente;
using SistemaTurnos.Migrations;
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
        public async Task<List<PacienteResponseDTO>> GetAll()
        {
            await Task.CompletedTask;
            Console.WriteLine("service");
            var pacientes = await _unitOfWork.PacienteRepository.GetAll();
            var rsta = _mapper.Map<List<PacienteResponseDTO>>(pacientes);
         
            return rsta;
        }

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
        }
    }
}