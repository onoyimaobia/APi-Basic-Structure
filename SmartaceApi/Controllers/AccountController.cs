using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Smartace.Application.Models.Payloads.AuthPayload;
using Smartace.Application.Models.Resources;
using Smartace.Application.Models.Resources.AuthResource;
using Smartace.Application.Services.AuthService.Interface;
using SmartaceApi.ModelHelper;

namespace SmartaceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : BaseController
    {
        private readonly IAuthenticationService authenticationService;
        public AccountController(IAuthenticationService authenticationService)
        {
            this.authenticationService = authenticationService;
        }
        ///<description>Log In</description>
        /// <summary>
        /// Completes a login into the system
        /// </summary>
        /// <remarks>
        /// Pass the valid email and the token to complete the login process  
        /// </remarks>
        /// <param name="payload"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult<ObjectResource<LoginResource>>> CreateToken([FromBody] LoginPayload payload)
        {
            var result = await authenticationService.LoginAsync(payload);
            return HandleResponse(result);
            
        }
        
    }
}
