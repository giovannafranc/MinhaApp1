using Microsoft.IdentityModel.Tokens;
using MinhaApp1.Interfaces;
using MinhaApp1.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MinhaApp1.Services
{
    public class AuthService : IAuthService
    {

        public string? Login(LoginAuth login)
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
                return new JwtSecurityTokenHandler().WriteToken(token);
            }

            return null;
        }
    }
}
