using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Dependencies;
using Microsoft.Practices.Unity;

namespace Player.WebAPI.App_Start
{
    public class UnityResolver : IDependencyResolver
    {
        private readonly IUnityContainer container;
        public UnityResolver(IUnityContainer container)
        {
            if (container == null)
            {
                throw new ArgumentNullException("container");
            }

            this.container = container;
        }
        public IDependencyScope BeginScope()
        {
            var child = this.container.CreateChildContainer();
            return new UnityResolver(child);
        }

        public void Dispose()
        {
            this.container.Dispose();
        }

        public object GetService(Type serviceType)
        {
            try
            {
                return this.container.Resolve(serviceType);
            }
            catch (ResolutionFailedException ex)
            {
                return null;
            }
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            try
            {
                return this.container.ResolveAll(serviceType);
            }
            catch (ResolutionFailedException ex)
            {
                return new List<object>();
            }
        }
    }
}