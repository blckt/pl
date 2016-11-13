using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Security;
using Microsoft.AspNet.Identity;
using Player.BLogic.Identity;
using Player.Contracts;
using Player.Core.DTO;
using Player.Core.Identity;

namespace Player.BLogic.Auth
{
    public class AuthorizationProvider
    {
        private readonly IReadWriteRepository<ApplicationUser> usersRepository;
        private readonly ApplicationUserManager userManager;
        public AuthorizationProvider(IReadWriteRepository<ApplicationUser> usersRepository, ApplicationUserManager userManager)
        {
            this.usersRepository = usersRepository;
            this.userManager = userManager;
        }

        public async Task<ClaimsIdentity> LogIn(string login, string password, bool isRemember)
        {
            ApplicationUser currentUser = await this.userManager.FindAsync(login, password);
            return await currentUser.GenerateUserIdentityAsync(this.userManager);

        }

        public async Task<IdentityResult> Registration(UserModel user)
        {
            var appUser = new ApplicationUser { UserName = user.UserName, Email = user.Email };
            var createResult = await this.userManager.CreateAsync(appUser, user.Password);
            return createResult;
        }

        private void AddUserToCookie(HttpResponseBase response, ApplicationUser user, bool isRemember)
        {
            FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(
                1,
                user.UserName,
                DateTime.Now,
                isRemember ? DateTime.Now.AddYears(1) : DateTime.Now.AddMinutes(30),
                true,
                user.Id.ToString(),
                FormsAuthentication.FormsCookiePath);

            string encryptedTicket = FormsAuthentication.Encrypt(authTicket);

            HttpCookie authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
            if (authTicket.IsPersistent)
            {
                authCookie.Expires = authTicket.Expiration;
            }

            response.Cookies.Add(authCookie);
        }
    }
}
