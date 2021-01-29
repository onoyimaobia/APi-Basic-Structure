using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

using Smartace.Application.Models.Constants;
using Smartace.Application.Models.Payloads.AuthPayload;
using Smartace.Application.Services.AuthService.Interface;
using System.Threading.Tasks;
using Xunit;

namespace Smartace.Test.Authentication
{
    public class AuthenticationTest: BaseTest
    {
        [Fact]
        public async Task LoginAsync_PassValidCredentials_ReturnSuccess()
        {
            var collection = GetCollection().BuildServiceProvider();
            var authLogin = collection.GetService<IAuthenticationService>();
            var tokengenerator = collection.GetService<ITokenGenerator>();
            var payload = new LoginPayload
            {
                Username = "Smartace",
                Password = "Smartace1$"
            };

            var tokenResult = await authLogin.LoginAsync(payload);

            Assert.Equals(ResourceCodes.Success, tokenResult.Code);

           
        }
    }
}
