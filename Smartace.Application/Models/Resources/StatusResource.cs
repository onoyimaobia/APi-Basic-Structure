using Smartace.Application.Models.Constants;
using System;
using System.Collections.Generic;
using System.Text;

namespace Smartace.Application.Models.Resources
{
    public class StatusResource
    {
        public string Code { get; set; } = ResourceCodes.Success;
        public string Message { get; set; }
        
    }
}
