using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using SecurityLab2.Models;

namespace SecurityLab2.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {

        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]

        public ActionResult Login(string username, string password, string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;

            var appContext = new AppContext();
            var userStore = new UserStore<AppUser>(appContext);
            var userManager = new UserManager<AppUser>(userStore);
            var authenticationManager = HttpContext.GetOwinContext().Authentication;
            var signInManager = new SignInManager<AppUser, string>(userManager, authenticationManager);

            var result = signInManager.PasswordSignIn(username, password, 
                isPersistent: false, shouldLockout:false);

            switch (result)
            {
                case SignInStatus.Success:
                    return RedirectToLocal(returnUrl); 
                default:
                    ModelState.AddModelError("", "Invalid login attempt.");
                    return View();
            }
        }

        public ActionResult LogOff()
        {
            var authenticationManager = HttpContext.GetOwinContext().Authentication;
            authenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return RedirectToAction("Index", "Home");
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");
        }
    }
}