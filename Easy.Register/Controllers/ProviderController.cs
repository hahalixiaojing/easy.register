using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Easy.Register.Controllers
{
    public class ProviderController : Controller
    {
        // GET: Provider
        public ActionResult Index()
        {
            ViewBag.Active = "Pro";
            return View();
        }

        public ActionResult Add()
        {
            ViewBag.Active = "Pro";
            return View();
        }
    }
}