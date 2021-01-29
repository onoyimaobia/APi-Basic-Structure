
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Smartace.Application.Models.Resources;
using static Smartace.Application.Models.Constants.ResourceCodes;

namespace SmartaceApi.Controllers
{
    
    public class BaseController : Controller
    {
        
        protected ActionResult<TRes> HandleResponse<TRes>(TRes result) where TRes : StatusResource
        {
            if (result.Code == ServiceError || result.Code == FeatureNotAvailable)
                return StatusCode(StatusCodes.Status500InternalServerError, result);

            if (result.Code == NoData) return NotFound(result);

            if (result.Code == Unauthenticated || result.Code[1] == '4') return Unauthorized(result);

            if (result.Code == Success) return Ok(result);

            return BadRequest(result);
        }
    }
    
}
