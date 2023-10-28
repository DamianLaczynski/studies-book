using Microsoft.AspNetCore.Mvc;
using studies_book.Models;
using studies_book.Services;

namespace studies_book.Controllers
{
    [ApiController]
    [Route("api/register")]
    public class RegisterController : ControllerBase
    {
        private readonly IRegisterService _registerService;

        public RegisterController(IRegisterService registerService)
        {
            _registerService=registerService;
        }

        [HttpPost]
        public IActionResult Register(RegisterDto registerDto)
        {
            _registerService.Register(registerDto);
            return Ok();
        }
    }
}
