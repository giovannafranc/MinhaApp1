using Microsoft.AspNetCore.Mvc;
using MinhaApp1.Interfaces;
using MinhaApp1.Models;


namespace MinhaApp1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class AuthController : ControllerBase
    {
        private readonly IAuthService _service;

        public AuthController(IAuthService service)
        {
            _service = service;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginAuth login)
        {
            var token = _service.Login(login);

            if (token == null) return Unauthorized();

            return Ok(new { token });
            
        }

    }
}





