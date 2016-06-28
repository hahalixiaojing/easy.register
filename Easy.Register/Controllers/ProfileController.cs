using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Easy.Register.Application.Models.Profile;
using Easy.Register.Utility;

namespace Easy.Register.Controllers
{
    [WebAuthorize]
    public class ProfileController : Controller
    {
        public ActionResult Index()
        {
            var list = Application.ApplicationRegistry.Profile.Select();

            return View(list);
        }

       
        public ActionResult Add()
        {
            return View();
        }

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

        public ActionResult Edit(int id)
        {
            var model = Application.ApplicationRegistry.Profile.FindBy(id);
            return View(model);
        }
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
    }
}