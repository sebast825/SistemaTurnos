using AutoMapper;
using Microsoft.AspNetCore.Server.IIS.Core;
using SistemaTurnos.Common;
using SistemaTurnos.Dal;
using SistemaTurnos.Dal.Entities;
using SistemaTurnos.Dto.DisponibilidadMedico;
using SistemaTurnos.Dto.Paciente;
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
        public async Task<DisponibilidadMedicoResponseDTO> Create(DisponibilidadMedicoCreateRequestDTO dto)
        {
          


            var medico= await _unitOfWork.MedicoRepository.GetId(dto.MedicoId);
            var disponibilidadMedico = await _unitOfWork.DisponibilidadMedicoRepository.GetByMedico(dto.MedicoId);
            var disponibilidadMedicoByDay =  disponibilidadMedico.Where(x => x.DiaSemanaId == dto.DiaSemanaId);

            var dia = await _unitOfWork.DiaSemanaRepository.GetId(dto.DiaSemanaId);

            if (disponibilidadMedicoByDay.Count() >= 2)
            {
                throw new Exception($"Ya tiene dos horarios para el dia de la semana {dia.Nombre}, debes editar el horario existente");
            }

            var idMedicoActivos =  _unitOfWork.DisponibilidadMedicoRepository.GetIdMedicosActivos();

            if (medico == null || medico.EstadoPersona == EstadoPersona.Activo)
            {
                /*    var newEntity = new DisponibilidadMedico
                    {
                        MedicoId = dto.MedicoId,                               
                        DiaSemanaId = dto.DiaSemanaId,
                        StartTime = TimeSpan.Parse(dto.StartTime),
                        EndTime = TimeSpan.Parse(dto.EndTime)

                    };*/
                var entity = _mapper.Map<DisponibilidadMedico>(dto);
                entity.DiaSemana = dia;
                await _unitOfWork.DisponibilidadMedicoRepository.Add(entity);
                await _unitOfWork.Save();
                return _mapper.Map<DisponibilidadMedicoResponseDTO>(entity);

            }
            throw new Exception("ya existe");


        }

        public async Task<List<DisponibilidadMedicoResponseDTO>> FilterByEspecialidad(int idEspecialidad)
        {
            var disponibildiadMedicos = await _unitOfWork.DisponibilidadMedicoRepository.FilterByEspecialidad(idEspecialidad);


            var rsta = _mapper.Map<List<DisponibilidadMedicoResponseDTO>>(disponibildiadMedicos);
            return rsta;
        }

        public async Task<List<DisponibilidadMedicoResponseDTO>> GetAll()
        {
          
            var disponibildiadMedicos = await _unitOfWork.DisponibilidadMedicoRepository.GetAll();

           
            var rsta = _mapper.Map<List<DisponibilidadMedicoResponseDTO>>(disponibildiadMedicos);
            return rsta;

        }

        public async Task<List<DisponibilidadMedicoResponseDTO>> GetByMedico(int idMedico)
        {

            var disponibildiadMedicos = await _unitOfWork.DisponibilidadMedicoRepository.GetByMedico(idMedico);


            var rsta = _mapper.Map<List<DisponibilidadMedicoResponseDTO>>(disponibildiadMedicos);
            return rsta;
        }

      
    }
}
