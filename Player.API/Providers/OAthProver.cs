using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security.OAuth;
using Player.BLogic.Identity;
using Player.Core.Identity;

namespace Player.API.Providers
{
    public class OAuthProvider: OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(
        OAuthValidateClientAuthenticationContext context)
        {
            string clientId;
            string clientSecret;

            if (context.TryGetBasicCredentials(out clientId, out clientSecret))
            {
                var userManager = DependencyResolver.Current.GetService<ApplicationUserManager>();
                var dbContext =
                    DependencyResolver.Current.GetService<DbContext>();

                try
                {
                    //Client client = await dbContext
                    //    .Clients
                    //    .FirstOrDefaultAsync(clientEntity => clientEntity.Id == clientId);

                    var client = await userManager.FindByIdAsync(clientId);

                    if (client != null &&
                        userManager.PasswordHasher.VerifyHashedPassword(
                            client.PasswordHash, clientSecret) == PasswordVerificationResult.Success)
                    {
                        // Client has been verified.
                        context.OwinContext.Set<ApplicationUser>("oauth:client", client);
                        context.Validated(clientId);
                    }
                    else
                    {
                        // Client could not be validated.
                        context.SetError("invalid_client", "Client credentials are invalid.");
                        context.Rejected();
                    }
                }
                catch
                {
                    // Could not get the client through the IClientManager implementation.
                    context.SetError("server_error");
                    context.Rejected();
                }
            }
            else
            {
                // The client credentials could not be retrieved.
                context.SetError(
                    "invalid_client",
                    "Client credentials could not be retrieved through the Authorization header.");

                context.Rejected();
            }
        }

        public override async Task GrantResourceOwnerCredentials(
            OAuthGrantResourceOwnerCredentialsContext context)
        {
            var client = context.OwinContext.Get<ApplicationUser>("oauth:client");

            // Client flow matches the requested flow. Continue...
            var userManager = DependencyResolver.Current.GetService<ApplicationUserManager>();

               ApplicationUser user;
                try
                {
                    user = await userManager.FindAsync(context.UserName, context.Password);
                }
                catch
                {
                    // Could not retrieve the user.
                    context.SetError("server_error");
                    context.Rejected();

                    // Return here so that we don't process further. Not ideal but needed to be done here.
                    return;
                }

                if (user != null)
                {
                    try
                    {
                        // User is found. Signal this by calling context.Validated
                        ClaimsIdentity identity = await userManager.CreateIdentityAsync(
                            user,
                            DefaultAuthenticationTypes.ExternalBearer);

                        context.Validated(identity);
                    }
                    catch
                    {
                        // The ClaimsIdentity could not be created by the UserManager.
                        context.SetError("server_error");
                        context.Rejected();
                    }
                }
                else
                {
                    // The resource owner credentials are invalid or resource owner does not exist.
                    context.SetError(
                        "access_denied",
                        "The resource owner credentials are invalid or resource owner does not exist.");

                    context.Rejected();
                }
          
        }
    }
}