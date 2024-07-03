using AutoMapper;
using SistemaTurnos.Dal;
using SistemaTurnos.Dto.Paciente;
using SistemaTurnos.Dto.Persona;
using SistemaTurnos.Service.Interface;

namespace SistemaTurnos.Service
{
    public class PersonaService : IPersonaService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public PersonaService(IUnitOfWork unitOfWork, IMapper mapper) { 
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<PersonaResponseDTO> ActualizarEstado(int dni, int estado)
        {

            if(estado  == 4) {
                throw new Exception("no puedes eliminar un usuario");

            }
            var dniString = dni.ToString();

            var persona = await _unitOfWork.PersonaRepository.GetByDni(dniString);
            if(persona != null) {

                persona.EstadoUsuarioId = estado;
               
                await _unitOfWork.Save();
                return _mapper.Map<PersonaResponseDTO>(persona);
            }
            
                throw new Exception("no se encontro");

            
        }

        public Task<PersonaResponseDTO> ActualizarEstadoEliminar(int dni)
        {
            throw new NotImplementedException();
        }
    }
}
