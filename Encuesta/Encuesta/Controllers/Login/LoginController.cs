using Encuesta.Data.Models;
using Encuesta.Helpers;
using Encuesta.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Encuesta.Controllers.Login
{
    [Route("api/[controller]/v1/")]
    [Produces("application/json")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _loginService;
        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        /// <summary>
        /// Loguea al usuario con el sistema
        /// </summary>
        [HttpPost("dologin")]
        [ProducesResponseType(200)]
        [ProducesResponseType(401)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> AutenticarUsuario(UserLogin login)
        {
            var user = await _loginService.ValidarCredencialesService(login);

            if (user != null) {
                var token = await _loginService.GenerarTokenService(user);
                return Ok(new ApiResponse<string>(token));
            }
            return NotFound();
        }
    }
}
