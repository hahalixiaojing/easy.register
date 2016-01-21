using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Easy.Register.Application;
using Easy.Register.Application.Models.Directory;

namespace Easy.Register.Controllers
{
    public class DirectoryController : Controller
    {
        // GET: Directory
        public ActionResult Index()
        {
            ViewBag.Active = "Dir";

            var model = ApplicationRegistry.Directory.Select(3);

            return View(model);
        }

        public ActionResult Add()
        {
            ViewBag.Active = "Dir";
            return View();
        }
    }
}