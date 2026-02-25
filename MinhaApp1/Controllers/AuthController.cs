using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginModel login)
    {
        if (login.Username == "admin" && login.Password == "123")
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("sua_chave_secreta_super_segura!!"));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, login.Username),
                new Claim("role", "Admin")
            };

            var token = new JwtSecurityToken(
                issuer: "suaempresa.com",
                audience: "suaempresa.com",
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: credentials
            );

            return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });
        }

        return Unauthorized();
    }
}

public class LoginModel
{
    public string Username { get; set; }
    public string Password { get; set; }
}
