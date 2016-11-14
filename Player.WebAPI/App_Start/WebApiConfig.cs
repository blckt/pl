using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web.Http;
using Newtonsoft.Json.Serialization;
using Player.WebAPI.App_Start;

namespace Player.WebAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Конфигурация и службы веб-API

            // Маршруты веб-API
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            config.DependencyResolver = new UnityResolver(UnityConfig.GetConfiguredContainer());
            var jsonformatter = config.Formatters.OfType<JsonMediaTypeFormatter>().First();
            jsonformatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        }
    }
}
