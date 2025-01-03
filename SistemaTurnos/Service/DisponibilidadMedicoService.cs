using AutoMapper;
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
        public async Task<DisponibilidadMedicoResponseDTO> Create(DisponibilidadMedicoCreateRequestDTO dto)
        {

            dto.StartTime = FormatHora(dto.StartTime);
            dto.EndTime = FormatHora(dto.EndTime);

            var entity = _mapper.Map<DisponibilidadMedico>(dto);

            if (entity.StartTime >= entity.EndTime)
            {
                throw new Exception("La hora de inicio debe ser menor a la de finalizacion");
            }

            var medico = await _unitOfWork.MedicoRepository.GetId(dto.MedicoId);

            if (medico == null)
            {
                throw new Exception("Medico invalido");
            }

            await _unitOfWork.DisponibilidadMedicoRepository.Add(entity);
            await _unitOfWork.Save();

            var rsta = await _unitOfWork.DisponibilidadMedicoRepository.GetById(entity.Id);

            return _mapper.Map<DisponibilidadMedicoResponseDTO>(rsta);


        }

        public async Task Delete(int id)
        {
            var disponibildiadMedico = await _unitOfWork.DisponibilidadMedicoRepository.GetById(id);
            try
            {
                _unitOfWork.DisponibilidadMedicoRepository.Delete(disponibildiadMedico);
                await _unitOfWork.Save();

            }
            catch (Exception ex)
            {
                throw new Exception("No se puedo eliminar el horario del medico");
            }

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

        public async Task<DisponibilidadMedicoResponseDTO> Update(DisponibilidadMedicoUpdateeRequestDTO dto)
        {

            dto.StartTime = FormatHora(dto.StartTime);
            dto.EndTime = FormatHora(dto.EndTime);

            var convert = _mapper.Map<DisponibilidadMedico>(dto);

            if (convert.StartTime >= convert.EndTime)
            {
                throw new Exception("La hora de inicio debe ser menor a la de finalizacion");
            }

            var disponibildiadMedicos = await _unitOfWork.DisponibilidadMedicoRepository.GetById(dto.id);

            disponibildiadMedicos.StartTime = convert.StartTime;
            disponibildiadMedicos.EndTime = convert.EndTime;

            //await _unitOfWork.DisponibilidadMedicoRepository.Edit(disponibildiadMedicos);
            await _unitOfWork.Save();

            //  var disponibildiadMedicos2 = await _unitOfWork.DisponibilidadMedicoRepository.GetId(dto.id);

            var rsta = _mapper.Map<DisponibilidadMedicoResponseDTO>(disponibildiadMedicos);

            return rsta;

            throw new NotImplementedException();
        }

        private string FormatHora(string fecha)
        {
            if (fecha.Length <= 2 && !fecha.Contains(":"))
            {

                return fecha + ":00";
            }
            return fecha;
        }
    }
}
