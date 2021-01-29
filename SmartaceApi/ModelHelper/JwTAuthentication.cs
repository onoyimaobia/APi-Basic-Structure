using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;


namespace SmartaceApi.ModelHelper
{
    public static class JwTAuthentication
    {
        public const string JwtKey = "JwtKey";
        public const string JwtKeyDefault = "PersonaJWTDeaultKey2020&411%#@3";

        public static void ConfigureAuthentication(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwt(configuration);

        }

        public static AuthenticationBuilder AddJwt(this AuthenticationBuilder builder, IConfiguration configuration)
        {
            var keyParam = configuration.GetValue(JwtKey, JwtKeyDefault);
            var key = Encoding.ASCII.GetBytes(keyParam);
            return builder.AddJwtBearer(x =>
            {


                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = false,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = configuration["JwtToken:Issuer"],
                    ValidAudience = configuration["JwtToken:Issuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtToken:SecretKey"])) //Configuration["JwtToken:SecretKey"]
                    //ValidateIssuerSigningKey = true,
                    //IssuerSigningKey = new SymmetricSecurityKey(key),
                    //ValidateIssuer = false,
                    //ValidateAudience = false
                };
            });
        }
        
    }
}
