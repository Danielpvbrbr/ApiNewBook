using ApiNewBook.DTOs;
using ApiNewBook.Services.AuthServices;
using Microsoft.AspNetCore.Mvc;

namespace ApiAlunos.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<ActionResult> Register(UsersCreateDTO usersCreateDTO)
        {
            var response = await _authService.Register(usersCreateDTO);

            return Ok(response);
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login(UsersLoginDTO usersLoginDTO)
        {
            var response = await _authService.Login(usersLoginDTO);

            return Ok(response);
        }
    }
}