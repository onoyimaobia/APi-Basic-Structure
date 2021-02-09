using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Smartace.Core.Domain.Account
{
    public class ApplicationUser : IdentityUser<long>
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
       //other fields
    }
}
