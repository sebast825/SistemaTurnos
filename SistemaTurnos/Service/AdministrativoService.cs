using AutoMapper;
using SistemaTurnos.Dal;
using SistemaTurnos.Dal.Entities;
using SistemaTurnos.Dto.Administrativo;
using SistemaTurnos.Dto.Medico;
using SistemaTurnos.Service.Interface;

namespace SistemaTurnos.Service
{
    public class AdministrativoService : IAdministrativoService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public AdministrativoService(IUnitOfWork unitOfWork, IMapper mapper) {

            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<AdministrativoResponseDTO> Create(AdministrativoRequestCreateDTO dto)
        {
            //var administrativo = await _unitOfWork.PersonaRepository.GetByDni(dto.NumeroDocumento);

            
                var entity = _mapper.Map<Administrativo>(dto);
                await _unitOfWork.AdministrativoRepository.Add(entity);
                await _unitOfWork.Save();
                return _mapper.Map<AdministrativoResponseDTO>(entity);

            
        }
    }
}
