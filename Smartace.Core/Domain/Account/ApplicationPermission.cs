using System;
using System.Collections.Generic;
using System.Text;

namespace Smartace.Core.Domain.Account
{
    public class ApplicationPermission
    {
        public ApplicationPermission()
        {
            ApplicationRolePermissions = new HashSet<ApplicationRolePermission>();
        }

        public long ID { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }

        public int ModuleID { get; set; }


        public virtual ICollection<ApplicationRolePermission> ApplicationRolePermissions { get; set; }
    }
}
