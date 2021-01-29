using System;
using System.Collections.Generic;
using System.Text;

namespace Smartace.Application.Services.AuthService.Interface
{
    public interface ITokenGenerator
    {
        string BuildJWTToken();

    }
}
