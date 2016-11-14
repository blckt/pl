using Microsoft.Practices.Unity;
using System.Web.Http;
using Unity.WebApi;
using System;
using Player.Core.Identity;
using Player.Data;
using Player.BLogic.Identity;
using System.Data.Entity;
using Microsoft.AspNet.Identity;
using Player.Data.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using Microsoft.Owin;
using Player.Contracts;
using Player.Data.Repositories;

namespace Player.API
{
    public static class UnityConfig
    {
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

        public static void RegisterTypes(IUnityContainer container)
        {
            container.RegisterType<DbContext, ApplicationDbContext>(new PerRequestLifetimeManager());
            container.RegisterType<ApplicationSignInManager>(new PerRequestLifetimeManager());
            container.RegisterType<IUserStore<ApplicationUser, string>, CustomUserStore>(new PerRequestLifetimeManager());
            container.RegisterType<IRoleStore<CustomRole, string>>(new PerRequestLifetimeManager());
            container.RegisterType<IReadWriteRepository<ApplicationUser>, Repository<ApplicationUser>>();
        //    container.RegisterType<IAuthenticationManager, >();
          //  container.RegisterType<ApplicationSignInManager>(new PerRequestLifetimeManager());
            container.RegisterType<ApplicationUserManager>(new PerRequestLifetimeManager());

        }

        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<ApplicationUserManager>(new PerRequestLifetimeManager());
            container.RegisterType<DbContext, ApplicationDbContext>(new PerRequestLifetimeManager());
            container.RegisterType<ApplicationSignInManager>(new PerRequestLifetimeManager());
            container.RegisterType<IUserStore<ApplicationUser, string>, CustomUserStore>(new PerRequestLifetimeManager());
            container.RegisterType<IRoleStore<CustomRole, string>>(new PerRequestLifetimeManager());
            container.RegisterType<ApplicationUserManager>(new PerRequestLifetimeManager());
            container.RegisterType<ApplicationSignInManager>(new PerRequestLifetimeManager());


            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}