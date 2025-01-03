using AutoMapper;
using SistemaTurnos.Common;
using SistemaTurnos.Dal;
using SistemaTurnos.Dal.Entities;
using SistemaTurnos.Dto.Especialidad;
using SistemaTurnos.Dto.Medico;
using SistemaTurnos.Service.Interface;

namespace SistemaTurnos.Service
{
    public class MedicoService : IMedicoService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public MedicoService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<MedicoResponseDTO> Create(MedicoCreateRequestDTO dto)
        {

            var medico = await _unitOfWork.PersonaRepository.GetByDni(dto.NumeroDocumento);
            //checkiar validacion
            if (medico == null || medico.EstadoPersona == EstadoPersona.Inactivo)
            {
                var entity = _mapper.Map<Medico>(dto);
                await _unitOfWork.MedicoRepository.Add(entity);
                await _unitOfWork.Save();
                return _mapper.Map<MedicoResponseDTO>(entity);

            }
            throw new Exception("ya existe");

        }

        public async Task<List<EspecialidadResponseDTO>> EspecialidadGetAll()
        {
            var listEspecialdiadeds = await _unitOfWork.EspecialidadRepository.GetAll();
            var rsta = _mapper.Map<List<EspecialidadResponseDTO>>(listEspecialdiadeds);
            return rsta;
        }

        public async Task<List<MedicoResponseDTO>> FilterByEspecialidad(int id)
        {
            var medicos = await _unitOfWork.MedicoRepository.FilterByEspecialidad(id);
            var rsta = _mapper.Map<List<MedicoResponseDTO>>(medicos);
            return rsta;
        }

        public async Task<List<MedicoResponseDTO>> GetAll()
        {
            var medicos = await _unitOfWork.MedicoRepository.GetAll();
            var rsta = _mapper.Map<List<MedicoResponseDTO>>(medicos);
            return rsta;
        }
        public async Task<MedicoResponseDTO> GetById(int id)
        {
            var medicos = await _unitOfWork.MedicoRepository.GetById(id);
            var rsta = _mapper.Map<MedicoResponseDTO>(medicos);
            return rsta;
        }

        public async Task<MedicoResponseDTO> Update(int id, MedicoUpdateRequestDTO dto)
        {

            var medico = await _unitOfWork.MedicoRepository.GetById(id);
            var especialidad = await _unitOfWork.EspecialidadRepository.GetId(dto.EspecialidadId);
            if (medico != null)
            {
                medico.NumeroLicencia = dto.NumeroLicencia;
                medico.EspecialidadId = dto.EspecialidadId;
            }
            else
            {
                throw new Exception("No se encontró el medico");
            }

            _unitOfWork.MedicoRepository.Edit(medico);
            await _unitOfWork.Save();

            medico.Especialidad = especialidad;


            var rsta = _mapper.Map<MedicoResponseDTO>(medico);
            return rsta;
        }
    }
}
