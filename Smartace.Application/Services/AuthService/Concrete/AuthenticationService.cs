using Microsoft.Extensions.Logging;
using Smartace.Application.Models.Constants;
using Smartace.Application.Models.Payloads.AuthPayload;
using Smartace.Application.Models.Resources;
using Smartace.Application.Models.Resources.AuthResource;
using Smartace.Application.Services.AuthService.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Smartace.Application.Services.AuthService.Concrete
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly ILogger<AuthenticationService> logger;
        private readonly ITokenGenerator tokenGenerator;
        public AuthenticationService(ILogger<AuthenticationService> logger, ITokenGenerator tokenGenerator)
        {
            this.tokenGenerator = tokenGenerator;
            this.logger = logger;
        }
        public async Task<ObjectResource<LoginResource>> LoginAsync(LoginPayload payload)
        {
            if (payload == null) {
                return new ObjectResource<LoginResource> { Code = ResourceCodes.NullPayload, Data = null, Message = "Payload cannot be null" }; }
            string tokenString = string.Empty;
            bool validUser = Authenticate(payload);
            if (validUser)
            {
                tokenString = tokenGenerator.BuildJWTToken();
                if(tokenGenerator == null)
                {
                    logger.LogError($"unable to generate token for user {payload.Username}");
                    return new ObjectResource<LoginResource> { Code = ResourceCodes.InvalidToken, Message = "unable to generate Token" };
                }
                logger.LogInformation($"Successfully generated token for {tokenString}");
                return new ObjectResource<LoginResource> { Code = ResourceCodes.Success, Data = new LoginResource { Token = tokenString, UserName = payload.Username }, Message = "Login Successful" };
            }
            else
            {
                logger.LogError($"Invalid Login payload:  {payload} at {DateTime.Now}");
                return new ObjectResource<LoginResource> { Code = ResourceCodes.InvalidLoginDetails, Data = null, Message = "password or username is incorrect" };
            }
            
            
        }
        private bool Authenticate(LoginPayload login)
        {
            bool validUser = false;

            if (login.Username == "Smartace" && login.Password == "Smartace1$")
            {
                validUser = true;
            }
            return validUser;
        }
    }
}
