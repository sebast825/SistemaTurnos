using AutoMapper;
using AutoMapper.Configuration.Conventions;
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
        public async Task<PersonaResponseDTO> ActualizarEstado(int id, int estado)
        {

            if(estado  == 4) {
                throw new Exception("no puedes eliminar un usuario");

            }
          

            var persona = await _unitOfWork.PersonaRepository.GetId(id);
            if(persona != null) {

                persona.EstadoUsuarioId = estado;
                persona.EstadoUsuario = await _unitOfWork.EstadoUsuarioRepository.GetId(estado);
                await _unitOfWork.Save();
                return _mapper.Map<PersonaResponseDTO>(persona);
            }
            
                throw new Exception("no se encontro");

            
        }
       
        public async Task<PersonaResponseDTO> ActualizarEstadoEliminar(int id)
        {

            var persona = await _unitOfWork.PersonaRepository.GetId(id);
            if (persona != null)
            {

                persona.EstadoUsuarioId = 4;
                persona.EstadoUsuario = await _unitOfWork.EstadoUsuarioRepository.GetId(4);
                await _unitOfWork.Save();
                return _mapper.Map<PersonaResponseDTO>(persona);
            }

            throw new Exception("no se encontro el usuario");
        }

        public Task<PersonaResponseDTO> ActualizarPersona(int id, PersonaUpdateRequestDTO dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Nombre))
                throw new ArgumentException("El nombre del disco es obligatorio.", nameof(dto.Nombre));

            if (string.IsNullOrWhiteSpace(dto.Apellido))
                throw new ArgumentException("El apellido es obligatorio.", nameof(dto.Apellido));

            throw new NotImplementedException();
        }
    }
}
