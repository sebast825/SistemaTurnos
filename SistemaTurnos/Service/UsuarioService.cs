using AutoMapper;
using SistemaTurnos.Common;
using SistemaTurnos.Dal;
using SistemaTurnos.Dal.Entities;
using SistemaTurnos.Dto.Persona;
using SistemaTurnos.Dto.User;
using SistemaTurnos.Service.Interface;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;

namespace SistemaTurnos.Service
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        public UsuarioService(IUnitOfWork unitOfWork, IMapper mapper, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _configuration = configuration;
        }



        public async Task CreatePaciente(UserCreateRequestDTO userDto, int pacietneId)
        {

            var existUser = await _unitOfWork.UsuarioRepository.GetByUser(userDto.UserName);
            if (existUser != null)
            {

                throw new Exception("El nombre de usuario no esta disponible");
            }
            Usuario usuario = new(Role.Paciente)
            {
                UserName = userDto.UserName,
                Password = HashPassword(userDto.Password),
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
            if (user != null)
            {

                //genero token
                string token = GetSha256(Guid.NewGuid().ToString());
                user.TokenRecovery = token;
                await _unitOfWork.Save();

                //enviar email
                SendEmail(dto.Email, token);
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
                }
                else if (estado == EstadoUsuario.Activo)
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

        private void SendEmail(string EmailDestino, string token)
        {

            try
            {
                string EmailOrigen = _configuration["CorreoSettings:EmailOrigen"];
                string Contrasenia = _configuration["CorreoSettings:Contrasenia"];
                string url = "http://localhost:3000/recuperarClave/?token=" + token;

                MailMessage oMailMessage = new MailMessage(EmailOrigen, EmailDestino, "Recuperacion de Contrasea",
                    "<p>Hemos recibido una solicitud para restablecer la contraseña de tu cuenta. Si fuiste " +
                    "tú quien solicitó este cambio, haz clic en el siguiente enlace para establecer una nueva contraseña:</p>" +
                    "<a href= '" + url + "'>Recuperar contraseña</a>" +
                    "<p>Si no solicitaste este cambio, por favor ignora este correo. Tu cuenta seguirá estando protegida." +
                    "Si tienes alguna duda o necesitas asistencia adicional, no dudes en contactarnos.</p>" +
                    "<p>Saludos, Clinica Horizonte Demo</p>");
                oMailMessage.IsBodyHtml = true;
                SmtpClient oSmtpClient = new SmtpClient();
                oSmtpClient.Host = "smtp.gmail.com";
                oSmtpClient.EnableSsl = true;
                oSmtpClient.UseDefaultCredentials = false;
                oSmtpClient.Port = 587;
                oSmtpClient.Credentials = new System.Net.NetworkCredential(EmailOrigen, Contrasenia);

                oSmtpClient.Send(oMailMessage);
                oSmtpClient.Dispose();

            }
            catch (Exception ex)
            {

                throw new Exception(ex.ToString());
            }
        }
        #region encriptado
        private string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }
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

        public async Task ActualizarClave(NuevaClaveRequestDTO dto)
        {
            var user = await _unitOfWork.UsuarioRepository.GetByToken(dto.Token);

            if (user != null)
            {
                user.Password = dto.Password;
                user.TokenRecovery = null;
                await _unitOfWork.Save();
            }
            else
            {
                throw new Exception("El token no es valido. Intenta recuperar tu clave nuevamente.");
            }
        }
        #endregion
    }
}

