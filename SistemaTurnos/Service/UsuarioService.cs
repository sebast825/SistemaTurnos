using AutoMapper;
using SistemaTurnos.Common;
using SistemaTurnos.Dal;
using SistemaTurnos.Dal.Entities;
using SistemaTurnos.Dto.Persona;
using SistemaTurnos.Dto.Turno;
using SistemaTurnos.Dto.User;
using SistemaTurnos.Service.Interface;

namespace SistemaTurnos.Service
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public UsuarioService(IUnitOfWork unitOfWork, IMapper mapper) {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }



        public async Task CreatePaciente(UserCreateRequestDTO userDto, int pacietneId)
        {


            Usuario usuario = new(Role.Paciente)
            {
                UserName = userDto.UserName,
                Password = userDto.Password,
                Email = userDto.Email,
                PersonaId = pacietneId
            };
            await _unitOfWork.UsuarioRepository.Add(usuario);
            await _unitOfWork.Save();

          
            throw new NotImplementedException();
        }
        public async Task<PersonaResponseDTO> UpdateEstado(int id, EstadoUsuario estado)
        {
            
            var persona = await _unitOfWork.PersonaRepository.GetId(id);

            var user = await _unitOfWork.UsuarioRepository.GetByPersonaId(persona.Id);


           

            if (user != null && persona != null)
            {

                if (user.EstadoUsuario == EstadoUsuario.Eliminado)
                {
                    throw new Exception("El usuario ya ha sido eliminado");
                }
                user.EstadoUsuario = estado;
              
                if ((estado == EstadoUsuario.Eliminado || estado == EstadoUsuario.Suspendido))
                {
                    persona.EstadoPersona = EstadoPersona.Inactivo;
                } else if (estado == EstadoUsuario.Activo)
                {
                    persona.EstadoPersona = EstadoPersona.Activo;

                }
                await _unitOfWork.Save();                            
                var rsta = _mapper.Map<PersonaResponseDTO>(persona);
                return rsta;

            }
            else
            {
                throw new Exception("El usuario no se encuentra disponible");

            }


        }
    }
}
