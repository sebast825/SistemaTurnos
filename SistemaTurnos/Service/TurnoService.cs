using AutoMapper;
using SistemaTurnos.Dal;
using SistemaTurnos.Dto.Turno;
using SistemaTurnos.Service.Interface;

namespace SistemaTurnos.Service
{
    public class TurnoService : ITurnoService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public TurnoService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<List<TurnoResponseDTO>> FilterByDoctor(int id)
        {
            var turnos = await _unitOfWork.TurnoRepository.FilterByDoctor(id);
            var rsta = _mapper.Map<List<TurnoResponseDTO>>(turnos);
            return rsta;
        }

        public Task<List<TurnoResponseDTO>> FilterByDoctorProgramedToday(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<TurnoResponseDTO>> FilterByEstadoTurno(EstadoTurno estado)
        {
            var turnos = await _unitOfWork.TurnoRepository.FilterByEstadoTurno(estado);
            var rsta = _mapper.Map<List<TurnoResponseDTO>>(turnos); 
            return rsta;
        }

        public async Task<List<TurnoResponseDTO>> FilterByPaciente(int id)
        {
            var turnos = await _unitOfWork.TurnoRepository.FilterByPaciente(id);
            var rsta = _mapper.Map<List<TurnoResponseDTO>>(turnos);
            return rsta;
        }

     
        public async Task<List<TurnoResponseDTO>> GetAll()
        {
            var turnos = await _unitOfWork.TurnoRepository.GetAll();
            var rsta =  _mapper.Map<List<TurnoResponseDTO>>(turnos);
            return rsta;
        }
    }
}
