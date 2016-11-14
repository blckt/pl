using System;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;
using Player.WebAPI.Providers;

[assembly: OwinStartup(typeof(Player.WebAPI.Startup))]

namespace Player.WebAPI
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // Дополнительные сведения о настройке приложения см. по адресу: http://go.microsoft.com/fwlink/?LinkID=316888
            HttpConfiguration config = new HttpConfiguration();
            WebApiConfig.Register(config);
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            app.UseWebApi(config);
        }
        public void ConfigureAuth(IAppBuilder app)
        {
            OAuthAuthorizationServerOptions options = new OAuthAuthorizationServerOptions()
            {
                AllowInsecureHttp = System.Diagnostics.Debugger.IsAttached,
                TokenEndpointPath = new PathString("/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(33),
                Provider = new SimpleAuthorizationServerProvider()
            };
        }
    }
}
