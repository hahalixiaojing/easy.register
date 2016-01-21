using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Easy.Register.Controllers
{
    public class ConsumerController : Controller
    {
        // GET: Consumer
        public ActionResult Index()
        {
            ViewBag.Active = "Cus";
            return View();
        }

        public ActionResult Add()
        {
            ViewBag.Active = "Cus";
            return View();
        }
    }
}