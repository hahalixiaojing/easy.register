using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Castle.Core.Internal;

namespace Easy.Register.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LoginPost(string userName, string password)
        {
            if (userName.IsNullOrEmpty() || password.IsNullOrEmpty())
            {
                return Redirect("/login/index");
            }

            return Redirect("/directory/index");
        }
    }
}