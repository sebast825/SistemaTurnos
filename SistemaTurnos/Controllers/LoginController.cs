using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using SistemaTurnos.Dto;
using SistemaTurnos.Service.Interface;
using SistemaTurnos.Dto.Login;

namespace SistemaTurnos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
    
        private readonly ILogger<LoginController> _logger;
        private readonly ILogService _logService;
        public LoginController(ILogger<LoginController> logger, ILogService logService)
        {
     
            _logger = logger;
            _logService = logService;
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<object>> Login(LoginRequestDTO login)
        {
            _logger.LogInformation("Inicio de Login");
            var rsta = await _logService.LogIn(login);
            //verificar el return
            return rsta;

        }
    }
}