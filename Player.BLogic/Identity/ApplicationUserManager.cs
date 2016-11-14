using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Player.Core.Identity;
using Player.Data;
using Player.Data.Identity;

namespace Player.BLogic.Identity
{
    public class ApplicationUserManager : UserManager<ApplicationUser, string>
    {
        public ApplicationUserManager(IUserStore<ApplicationUser, string> store) : base(store)
        {
            ////this.RoleManager = roleManager; 
           // this.UserValidator = new UserValidator<ApplicationUser, string>(this)
           // {
           //     AllowOnlyAlphanumericUserNames = false,
           //     RequireUniqueEmail = true
           // };

           //// Настройка логики проверки паролей
           // this.PasswordValidator = new PasswordValidator
           // {
           //     RequiredLength = 6
           // };

           // //Настройка параметров блокировки по умолчанию
           // this.UserLockoutEnabledByDefault = true;
           // this.DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(5);
           // this.MaxFailedAccessAttemptsBeforeLockout = 5;

        }
        public static ApplicationUserManager Create(IdentityFactoryOptions<ApplicationUserManager> options,IOwinContext context)
        {
            var manager = new ApplicationUserManager(new CustomUserStore(context.Get<DbContext>()));
            manager.UserValidator = new UserValidator<ApplicationUser,string>(manager)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = true
            };

            // Настройка логики проверки паролей
            manager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 6
            };

            // Настройка параметров блокировки по умолчанию
            manager.UserLockoutEnabledByDefault = true;
            manager.DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(5);
            manager.MaxFailedAccessAttemptsBeforeLockout = 5;

            // Регистрация поставщиков двухфакторной проверки подлинности. Для получения кода проверки пользователя в данном приложении используется телефон и сообщения.
            // Здесь можно указать собственный поставщик и подключить его.
            //manager.RegisterTwoFactorProvider("Код, полученный по телефону", new PhoneNumberTokenProvider<ApplicationUser>
            //{
            //    MessageFormat = "Ваш код безопасности: {0}"
            //});
            //manager.RegisterTwoFactorProvider("Код из сообщения", new EmailTokenProvider<ApplicationUser>
            //{
            //    Subject = "Код безопасности",
            //    BodyFormat = "Ваш код безопасности: {0}"
            //});
            //manager.EmailService = new EmailService();
            //manager.SmsService = new SmsService();
            //var dataProtectionProvider = options.DataProtectionProvider;
            //if (dataProtectionProvider != null)
            //{
            //    manager.UserTokenProvider =
            //        new DataProtectorTokenProvider<ApplicationUser>(dataProtectionProvider.Create("ASP.NET Identity"));
            //}

            return manager;

        }
    }
}
