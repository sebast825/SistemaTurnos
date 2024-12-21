using AutoMapper;
using SistemaTurnos.Common;
using SistemaTurnos.Dal;
using SistemaTurnos.Dal.Entities;
using SistemaTurnos.Dto.Persona;
using SistemaTurnos.Dto.Turno;
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
        public async Task<PersonaResponseDTO> UpdateEstado(int id, EstadoUsuario estado)
        {
            var user = await _unitOfWork.UsuarioRepository.GetById(id);
            var persona = await _unitOfWork.PersonaRepository.GetId(user.Id);

            if (user.EstadoUsuario == EstadoUsuario.Eliminado)
            {
                throw new Exception("El usuario ya ha sido eliminado");
            }

            if (user != null && persona != null)
            {
                user.EstadoUsuario = estado;
              
                if ((estado == EstadoUsuario.Eliminado || estado == EstadoUsuario.Suspendido))
                {
                    persona.EstadoPersona = EstadoPersona.Inactivo;
                } else if (estado == EstadoUsuario.Activo)
                {
                    persona.EstadoPersona = EstadoPersona.Activo;

                }
                _unitOfWork.Save();                            
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
