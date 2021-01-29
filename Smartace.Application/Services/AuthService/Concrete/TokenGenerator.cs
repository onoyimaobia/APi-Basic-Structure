using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Smartace.Application.Services.AuthService.Interface;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace Smartace.Application.Services.AuthService.Concrete
{
    public class JWTTokenGenerator : ITokenGenerator
    {
        private readonly IConfiguration configuration;
        //private readonly ILogger<JwtTokenGenerator> jwtLogger;

        public JWTTokenGenerator(IConfiguration configuration)
        {
            this.configuration = configuration;
            //this.jwtLogger = jwtLogger;
        }
        public string BuildJWTToken()
        {

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtToken:SecretKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var issuer = configuration["JwtToken:Issuer"];
            var audience = configuration["JwtToken:Issuer"];
            var jwtValidity = DateTime.Now.AddMinutes(Convert.ToDouble(configuration["JwtToken:TokenExpiry"]));

            var token = new JwtSecurityToken(issuer,
              audience,
              expires: jwtValidity,
              signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
