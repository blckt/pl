using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using Player.Core.Identity;

namespace Player.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, CustomRole, string, CustomUserLogin, CustomUserRole, CustomUserClaim>
    {
        public ApplicationDbContext() : base("DefaultConnection")
        {
            this.Configuration.LazyLoadingEnabled = true;
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}
