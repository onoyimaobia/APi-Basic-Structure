using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartaceApi.ModelHelper
{
    public class JWTTokenGenerator: ITokenGenerator
    {
        private readonly IConfiguration configuration;
        //private readonly ILogger<JwtTokenGenerator> jwtLogger;

        public JWTTokenGenerator(IConfiguration configuration)
        {
            this.configuration = configuration;
            //this.jwtLogger = jwtLogger;
        }
        public  string BuildJWTToken()
        {
            
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration.GetValue<string>("JwtToken:SecretKey")));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var issuer = configuration.GetValue<string>("JwtToken:Issuer");
            var audience = configuration.GetValue<string>("JwtToken:Issuer");
            var jwtValidity = DateTime.Now.AddMinutes(Convert.ToDouble(configuration.GetValue<string>("JwtToken:TokenExpiry")));

            var token = new JwtSecurityToken(issuer,
              audience,
              expires: jwtValidity,
              signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
