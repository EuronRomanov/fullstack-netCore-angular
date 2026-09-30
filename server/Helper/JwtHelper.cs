using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using server.Entities;

namespace server.Helper
{
    public class JwtHelper : IJwtHelper
    {

        private readonly IConfiguration _config;

        public JwtHelper(IConfiguration config)
        {
            this._config=config;
        }
        public string GenerateJwtToken(User user)
        {
            var securityKey=new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]?? 
            throw new Exception("Jwt key is missing"))
            );

            var credential=new SigningCredentials(securityKey,SecurityAlgorithms.HmacSha512);

            List<Claim> claims=new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Sid, user.UserId.ToString()),
                 new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim("Date",DateTime.Now.ToString()),
            };

            var token=new JwtSecurityToken(
                _config["Jwt:Issuer"],
                _config["Jwt:Issuer"],
                claims.ToArray(),
                notBefore:DateTime.Now,
                expires:DateTime.Now.AddMinutes(20),
                signingCredentials: credential
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}