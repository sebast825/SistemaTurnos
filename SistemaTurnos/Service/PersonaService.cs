using AutoMapper;
using SistemaTurnos.Dal;
using SistemaTurnos.Dto.Paciente;
using SistemaTurnos.Dto.Persona;
using SistemaTurnos.Migrations;
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
                persona.EstadoUsuario = await _unitOfWork.EstadoUsuarioRepository.GetId(estado);
                await _unitOfWork.Save();
                return _mapper.Map<PersonaResponseDTO>(persona);
            }
            
                throw new Exception("no se encontro");

            
        }
       
        public async Task<PersonaResponseDTO> ActualizarEstadoEliminar(int dni)
        {
            var dniString = dni.ToString();

            var persona = await _unitOfWork.PersonaRepository.GetByDni(dniString);
            if (persona != null)
            {

                persona.EstadoUsuarioId = 4;
                persona.EstadoUsuario = await _unitOfWork.EstadoUsuarioRepository.GetId(4);
                await _unitOfWork.Save();
                return _mapper.Map<PersonaResponseDTO>(persona);
            }

            throw new Exception("no se encontro el usuario");
        }
    }
}
