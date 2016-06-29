using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Easy.Register.Application;
using Easy.Register.Application.Models.Profile;
using Easy.Register.Utility;

namespace Easy.Register.Controllers
{
    public class ProfileController : Controller
    {
        [WebAuthorize]
        public ActionResult Index()
        {
            var list = Application.ApplicationRegistry.Profile.Select();

            return View(list);
        }
        [WebAuthorize]
        public ActionResult Add()
        {
            return View();
        }
        [WebAuthorize]
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Save(CreateProfileModel model)
        {
            try
            {
                Application.ApplicationRegistry.Profile.Create(model);
                ViewBag.Ok = "ok";
            }
            catch {

            }
            return View();
        }
        [WebAuthorize]
        public ActionResult Edit(int id)
        {
            var model = Application.ApplicationRegistry.Profile.FindBy(id);
            return View(model);
        }
        [WebAuthorize]
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Update(string content, int id)
        {
            try
            {
                Application.ApplicationRegistry.Profile.Update(content, id);
                ViewBag.Ok = "ok";
            }
            catch { }
            return View("~/Views/Profile/Save.cshtml");
        }

        [HttpGet]
        public ActionResult Pull(string application,string profile)
        {
            string content = ApplicationRegistry.Profile.FindProfileContent(application, profile);
            return Content(content);
        }
    }
}