using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Player.Contracts;

namespace Player.Core.Identity
{
  public  class ApplicationUser: IdentityUser<string,CustomUserLogin,CustomUserRole,CustomUserClaim>,IEntity
    {
        public bool Blocked { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(
         UserManager<ApplicationUser, string> manager)
        {
            // Note the authenticationType must match the one defined in
            // CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(
                this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
}
