using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security.OAuth;
using Player.BLogic.Identity;

namespace Player.BLogic.Auth
{
   public class TokenAuthProvider: OAuthAuthorizationServerProvider
    {
        private readonly ApplicationUserManager userManager;
        public TokenAuthProvider(ApplicationUserManager userManager)
        {
            this.userManager = userManager;
        }
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }
        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {

            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });

            var appUser = await this.userManager.FindAsync(context.UserName, context.Password);
            if (appUser == null)
            {
                context.SetError("invalid_grant", "The user name or password is incorrect");
                return;
            }
                        
            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
                
            context.Validated(identity);

        }
    }
}
