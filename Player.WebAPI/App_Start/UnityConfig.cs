using System;
using System.Data.Entity;
using Microsoft.AspNet.Identity;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using Player.BLogic.Identity;
using Player.Contracts;
using Player.Core.Identity;
using Player.Data;
using Player.Data.Identity;
using Player.Data.Repositories;

namespace Player.WebAPI.App_Start
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container = new Lazy<IUnityContainer>(() =>
        {
            var container = new UnityContainer();
            RegisterTypes(container);
            return container;
        });

        /// <summary>
        /// Gets the configured Unity container.
        /// </summary>
        public static IUnityContainer GetConfiguredContainer()
        {
            return container.Value;
        }
        #endregion

        /// <summary>Registers the type mappings with the Unity container.</summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>There is no need to register concrete types such as controllers or API controllers (unless you want to 
        /// change the defaults), as Unity allows resolving a concrete type even if it was not previously registered.</remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            // NOTE: To load from web.config uncomment the line below. Make sure to add a Microsoft.Practices.Unity.Configuration to the using statements.
            // container.LoadConfiguration();

            // TODO: Register your types here
            // container.RegisterType<IProductRepository, ProductRepository>();
            container.RegisterType<DbContext, ApplicationDbContext>(new PerRequestLifetimeManager());
            container.RegisterType<ApplicationSignInManager>(new PerRequestLifetimeManager());
            container.RegisterType<IUserStore<ApplicationUser, string>, CustomUserStore>(new PerRequestLifetimeManager());
            container.RegisterType<IRoleStore<CustomRole, string>>(new PerRequestLifetimeManager());
            container.RegisterType<IReadWriteRepository<ApplicationUser>, Repository<ApplicationUser>>();
            //    container.RegisterType<IAuthenticationManager, >();
            //  container.RegisterType<ApplicationSignInManager>(new PerRequestLifetimeManager());
            container.RegisterType<ApplicationUserManager>(new PerRequestLifetimeManager());
        }
    }
}
