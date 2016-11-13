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
    public class CustomUserStore : UserStore<ApplicationUser, CustomRole, string, CustomUserLogin, CustomUserRole, CustomUserClaim>
    {
        public CustomUserStore(DbContext context) : base(context)
        {
        }
    }
}
