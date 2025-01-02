
using SistemaTurnos.Service.Interface;
using SistemaTurnos.Dal;
using SistemaTurnos.Dal.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using SistemaTurnos.Dto.Login;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using SistemaTurnos.Common;

namespace SistemaTurnos.Service
{
    public class LogService : ILogService
    {
        private IConfiguration _configuration;
 
        private readonly IUnitOfWork _unitOfWork;
        public LogService(IUnitOfWork unitOfWork,
            IConfiguration configuration )
        {
            _unitOfWork = unitOfWork;
            _configuration = configuration;

        }

        public async Task<Usuario> GetUsuarioByUserPass(string user, string pass)
        {
            var usuario = await _unitOfWork.UsuarioRepository.GetByUser(user);
            if (usuario == null)
            {
             
                return null;
            }
            else if (!VerifyPassword(pass, usuario.Password))
            {
                
                return null;
            }
            return usuario;
        }

        public async Task<object> LogIn(LoginRequestDTO login)
        {
            var userEntity = await GetUsuarioByUserPass(login.UserName, login.Password);
            if (userEntity != null)
            {
                isUserActive(userEntity.EstadoUsuario);
                var permiso = userEntity.Role.ToString();
                                
                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub,_configuration["Jwt:Subject"]),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                    new Claim("UserId", userEntity.Id.ToString()),
                    new Claim("PersonaId", userEntity.PersonaId.ToString()),
                     new Claim(ClaimTypes.Role, permiso),
                    new Claim("UserName", userEntity.UserName),
                };
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var token = new JwtSecurityToken(
                    _configuration["Jwt:Issuer"],
                    _configuration["Jwt:Audience"],
                    claims,
                    expires: DateTime.UtcNow.AddMinutes(10),
                    signingCredentials: signIn);

                return new JwtSecurityTokenHandler().WriteToken(token);
            }
            else
            {
                throw new Exception("Usuario o contraseña invalida");
            }
        }
        private void isUserActive(EstadoUsuario estado)
        {
            if(estado != EstadoUsuario.Activo)
            {
                throw new Exception("El usuario esta bloqueado.");
            }
        }
        public string GetClaimValueFromJwt(string token, string claimName)
        {

            // Verificar si el token es válido
            if (string.IsNullOrEmpty(token))
            {
                throw new Exception("Empty token"); // null devolver un error
            }

            // Usar una librería para decodificar el token JWT
            // Ejemplo usando System.IdentityModel.Tokens.Jwt
            var handler = new JwtSecurityTokenHandler();
            var jwtSecurityToken = handler.ReadJwtToken(token);

            // Obtener el claim por nombre
            var claim = jwtSecurityToken.Claims.FirstOrDefault(c => c.Type == claimName);

            return claim.Value;
          
        }

      

        private bool VerifyPassword(string password, string hashedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
        }
    }
}
