using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using Player.Core.Identity;

namespace Player.Data.Identity
{
    public class CustomRoleStore : RoleStore<CustomRole, string, CustomUserRole>
    {
        public CustomRoleStore(DbContext context) : base(context)
        {
        }
    }
}
