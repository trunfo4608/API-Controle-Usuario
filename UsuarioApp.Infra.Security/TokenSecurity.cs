using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using UsuarioApp.Domain.Entities;
using UsuarioApp.Domain.Interfaces;

namespace UsuarioApp.Infra.Security
{
    public class TokenSecurity : ITokenSecurity
    {
        public static string Secretkey = "qasedrbuio@#$@y97451tghup65der98";

        public string CreateToken(Usuario usuario)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, usuario.Email),
                new Claim(ClaimTypes.Role, "USER")
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Secretkey));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddHours(5),
                signingCredentials: credentials
                );


            var tokenHandler = new JwtSecurityTokenHandler();
            return tokenHandler.WriteToken(jwtSecurityToken);
        }
    }
}
