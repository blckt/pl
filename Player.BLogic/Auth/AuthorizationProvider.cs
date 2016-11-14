using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
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

        public  IdentityResult Registration(UserModel user)
        {
            var appUser = new Player.Core.Identity.ApplicationUser { UserName = user.UserName, Email = user.Email, Id = Guid.NewGuid().ToString() };
            try
            {
                var createResult = this.userManager.Create(appUser);
                return createResult;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<ApplicationUser> FindUser(string login,string password)
        {
            return await this.userManager.FindAsync(login, password);
        }
        public void Dispose()
        {
            userManager.Dispose();
        }
    }
}
