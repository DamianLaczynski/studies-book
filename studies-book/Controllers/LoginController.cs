using Microsoft.AspNetCore.Mvc;
using studies_book.Entities;
using studies_book.Models;
using studies_book.Services;

namespace studies_book.Controllers
{
    [ApiController]
    [Route("api/login")]
    public class LoginController : ControllerBase
    {

        private readonly ILoginService _loginService;
        private readonly ITokenService _tokenService;

        public LoginController(ILoginService loginService, ITokenService tokenService)
        {
            _loginService = loginService;
            _tokenService = tokenService;
        }


        [HttpPost()]
        public IActionResult Login(LoginDto loginDto)
        {
            User user = _loginService.Login(loginDto);
            var token = _tokenService.GenerateToken(user);
            return Ok(token);
        }
        
    }
}
