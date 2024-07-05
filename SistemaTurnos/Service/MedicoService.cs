using AutoMapper;
using SistemaTurnos.Dal;
using SistemaTurnos.Dal.Entities;
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
            Console.WriteLine(dto.NumeroDocumento);

            var medico = await _unitOfWork.PersonaRepository.GetByDni(dto.NumeroDocumento);
          
            if (medico == null || medico.EstadoUsuario.Nombre == "Eliminado")
            {
                var entity = _mapper.Map<Medico>(dto);
                await _unitOfWork.MedicoRepository.Add(entity);
                await _unitOfWork.Save();
                return _mapper.Map<MedicoResponseDTO>(entity);

            }
            throw new Exception("ya existe");

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
    }
}
