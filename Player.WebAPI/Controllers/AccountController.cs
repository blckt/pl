using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using Player.BLogic.Auth;
using Player.WebAPI.Models;

namespace Player.WebAPI.Controllers
{
    [RoutePrefix("api/Account")]
    public class AccountController : ApiController
    {
        private readonly AuthorizationProvider AuthProvider;
       
        public AccountController(AuthorizationProvider authProvider)
        {
            this.AuthProvider = authProvider;
        }

        [AllowAnonymous]
        [Route("Register")]
        public async Task<IHttpActionResult> Register(RegisterViewModel model)
        {

            if (ModelState.IsValid)
            {
                var result =  AuthProvider.Registration(new Core.DTO.UserModel { Email = model.Email, Password = model.Password, UserName = model.UserName });
                if (result.Succeeded)
                {
                    return this.Ok();
                }
                else
                {
                    return GetErrorResult(result);
                }
            }
            return this.BadRequest(ModelState);
        }
        private IHttpActionResult GetErrorResult(IdentityResult result)
        {
            if (result == null)
            {
                return InternalServerError();
            }

            if (!result.Succeeded)
            {
                if (result.Errors != null)
                {
                    foreach (string error in result.Errors)
                    {
                        ModelState.AddModelError("", error);
                    }
                }

                if (ModelState.IsValid)
                {
                    // No ModelState errors are available to send, so just return an empty BadRequest.
                    return BadRequest();
                }

                return BadRequest(ModelState);
            }

            return null;
        }
    }
}
