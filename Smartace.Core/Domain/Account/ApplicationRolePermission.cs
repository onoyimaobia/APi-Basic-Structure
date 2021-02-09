using System;
using System.Collections.Generic;
using System.Text;

namespace Smartace.Core.Domain.Account
{
    public class ApplicationRolePermission
    {
        public ApplicationRolePermission()
        {
            DateCreated = DateTime.Now;
        }

        public int ID { get; set; }
        public DateTime DateCreated { get; set; }
        public long ApplicationRoleId { get; set; }
        public long ApplicationPermissionId { get; set; }


        public virtual ApplicationRole ApplicationRole { get; set; }
        public virtual ApplicationPermission ApplicationPermission { get; set; }
    }
}
