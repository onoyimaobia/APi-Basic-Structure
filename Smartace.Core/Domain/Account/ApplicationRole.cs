using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Smartace.Core.Domain.Account
{
    public class ApplicationRole : IdentityRole<long>
    {
        public ApplicationRole()
        {
            ApplicationRolePermissions = new HashSet<ApplicationRolePermission>();
        }


        public string Description { get; set; }
        public bool IsSystemRole { get; set; }

        public virtual ICollection<ApplicationRolePermission> ApplicationRolePermissions { get; set; }
    }
}

