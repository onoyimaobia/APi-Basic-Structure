using Smartace.Application.Models.Payloads.AuthPayload;
using Smartace.Application.Models.Resources;
using Smartace.Application.Models.Resources.AuthResource;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Smartace.Application.Services.AuthService.Interface
{
    public interface IAuthenticationService
    {
        Task<ObjectResource<LoginResource>> LoginAsync(LoginPayload payload);
    }
}
