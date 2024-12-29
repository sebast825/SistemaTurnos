using AutoMapper;
using SistemaTurnos.Common;
using SistemaTurnos.Dal;
using SistemaTurnos.Dal.Entities;
using SistemaTurnos.Dto.Persona;
using SistemaTurnos.Dto.Turno;
using SistemaTurnos.Dto.User;
using SistemaTurnos.Service.Interface;
using System.Security.Cryptography;
using System.Text;

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

            var existUser = await _unitOfWork.UsuarioRepository.GetByUser(userDto.UserName);
            if (existUser != null) {

                throw new Exception("El nombre de usuario no esta disponible");
            }
            Usuario usuario = new(Role.Paciente)
            {
                UserName = userDto.UserName,
                Password = userDto.Password,
                Email = userDto.Email,
                PersonaId = pacietneId
            };
            await _unitOfWork.UsuarioRepository.Add(usuario);
            await _unitOfWork.Save();

            return;
            throw new NotImplementedException();
        }

        public async Task StartRecoveryPassword(RecoveryEmailRequestDo dto)
        {
            var user = await _unitOfWork.UsuarioRepository.GetByEmail(dto.Email);
            if (user != null) {
            
                string token = GetSha256(Guid.NewGuid().ToString());
                user.TokenRecovery = token;

                await _unitOfWork.Save();
               
                }
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
#region encriptado
        private string GetSha256(string str)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(str);
                byte[] hash = sha256.ComputeHash(bytes);

                StringBuilder result = new StringBuilder();
                foreach (byte b in hash)
                {
                    result.Append(b.ToString("x2"));
                }

                return result.ToString();
            }
        }
#endregion
    }
}

