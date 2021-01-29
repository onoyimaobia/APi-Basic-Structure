using System;
using System.Collections.Generic;
using System.Text;

namespace Smartace.Application.Models.Resources
{
    public class ObjectResource<TObject> : StatusResource
    {
        public TObject Data { get; set; }
    }
}
