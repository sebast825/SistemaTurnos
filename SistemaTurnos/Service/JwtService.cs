using SistemaTurnos.Service.Interface;
using System.IdentityModel.Tokens.Jwt;

namespace SistemaTurnos.Service
{
    public class JwtService : IJwtService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public JwtService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
      
        private string GetClaimValueFromJwt(string claimName)
        {
            var token = _httpContextAccessor.HttpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

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

        public bool UserMatchRequestId(int id)
        {
            var tokenId = GetClaimValueFromJwt("PersonaId");
            return tokenId == id.ToString() ? true : false;


        }
    }
}
