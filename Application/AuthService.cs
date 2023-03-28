using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SeguroAutoAPI.Application.Contracts;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SeguroAutoAPI.Application
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _configuration;

        public AuthService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public IActionResult Login(string username, string password)
        {
            if (!ValidateUser(username, password))
            {
                return new UnauthorizedResult();
            }

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, username),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expiry = DateTime.Now.AddMinutes(10);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Issuer"],
                claims: claims,
                expires: expiry,
                signingCredentials: creds
            );

            return new OkObjectResult(new { token = new JwtSecurityTokenHandler().WriteToken(token), expiration = expiry });
        }

        // Aquí debe agregar la lógica para validar las credenciales del usuario, por ejemplo, consultando una base de datos.
        // Este método es solo un ejemplo simplificado.
        public bool ValidateUser(string username, string password)
        {
            return username == "1234" && password == "1234";
        }
    }
}
