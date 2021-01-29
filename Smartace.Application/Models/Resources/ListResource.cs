using System;
using System.Collections.Generic;
using System.Text;

namespace Smartace.Application.Models.Resources
{
    public class ListResource<TResource> : StatusResource
    {
        public long Total { get; set; }
        public IEnumerable<TResource> Data { get; set; }
    }
}
