using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Player.API.Models;
using Player.BLogic.Auth;
using Player.BLogic.Identity;

namespace Player.API.Controllers
{
    public class AccountController : Controller
    {
        private readonly AuthorizationProvider UserManager;
        public AccountController()
        {
        }
        public AccountController(AuthorizationProvider userManager)
        {
            this.UserManager = userManager;
        }

        public ActionResult Authorize()
        {
            return this.View("Login");
        }


        public async Task<ActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await this.UserManager.LogIn(model.Email, model.Password, model.RememberMe);
            }
            return new HttpStatusCodeResult(200);
        }

        public ActionResult Register()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            if (this.ModelState.IsValid)
            {
               var result = await this.UserManager.Registration(new Core.DTO.UserModel { Email = model.Email, Password = model.Password, UserName = model.UserName });
                if (result.Succeeded)
                {
                    ViewBag.Message = "Успех!";
                } else
                {
                    ViewBag.Errors = result.Errors;
                }
                return new HttpStatusCodeResult(200);
            }
            return this.View();
        }
        
    }
}