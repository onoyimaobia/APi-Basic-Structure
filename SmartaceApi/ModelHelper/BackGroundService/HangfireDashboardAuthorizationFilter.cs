using Hangfire.Dashboard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SmartaceApi.ModelHelper.BackGroundService
{
    public class HangfireDashboardAuthorizationFilter : IDashboardAuthorizationFilter
    {
        //this can be changed
        public bool Authorize(DashboardContext context)
        {
            bool response = false;
            var httpContext = context.GetHttpContext();
            var userRole = httpContext.User.FindFirst(ClaimTypes.Role)?.Value;
            return response;
        }
    }
}
