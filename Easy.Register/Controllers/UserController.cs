using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Easy.Register.Controllers
{
    public class UserController : Controller
    {
        public UserController()
        {
            ViewBag.Active = "User";

        }

        public ActionResult Index()
        {
            var users = Application.ApplicationRegistry.User.FindAll();
            return View(users);
        }
        public ActionResult UpdateUser(int userId)
        {
            var user = Application.ApplicationRegistry.User.FindBy(userId);
            return View(user);
        }

        public ActionResult EditPassword(int userId)
        {
            var user = Application.ApplicationRegistry.User.FindBy(userId);
            return View(user);
        }
        [HttpPost]
        public ActionResult EditPassword(int userId,string password)
        {
            var r = Application.ApplicationRegistry.User.UpdatePassword(userId, password);
            if (string.IsNullOrEmpty(r))
            {
                ViewBag.Ok = "ok";
                return View("AddPost");
            }
            ViewBag.Ok = r;
            return View("AddPost");
        }


        [HttpPost]
        public ActionResult UpdateUser(int userid,string username, string name)
        {
            var r = Application.ApplicationRegistry.User.UpdateUser(userid, username, name);
            if (string.IsNullOrEmpty(r))
            {
                ViewBag.Ok = "ok";
                return View("AddPost");
            }
            ViewBag.Ok = r;
            return View("AddPost");
        }

        public ActionResult AddUser()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddUser(string username,string name,string password)
        {
           string r = Application.ApplicationRegistry.User.Add(username, name, password);
            if (string.IsNullOrEmpty(r))
            {
                ViewBag.Ok = "ok";
                return View("AddPost");
            }
            ViewBag.Ok = r;
            return View("AddPost");
        }
    }
}