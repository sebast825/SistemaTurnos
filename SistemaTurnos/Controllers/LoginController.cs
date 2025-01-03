using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SistemaTurnos.Dto.Login;
using SistemaTurnos.Service.Interface;

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