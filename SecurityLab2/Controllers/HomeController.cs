using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SecurityLab2.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "admins")]
        public ActionResult SuperSecret()
        {
            return Content("This is a secret only for admins!");
        }

        [Authorize]
        public ActionResult Secret()
        {
            return Content("This is a secret!");
        }

    }
}