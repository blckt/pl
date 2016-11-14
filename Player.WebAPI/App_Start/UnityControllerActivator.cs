using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;

namespace Player.WebAPI.App_Start
{
    public class UnityControllerActivator : IHttpControllerActivator
    {

        public IHttpController Create(HttpRequestMessage request, HttpControllerDescriptor controllerDescriptor, Type controllerType)
        {
            throw new NotImplementedException();
        }
    }
}