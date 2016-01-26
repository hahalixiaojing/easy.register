using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Easy.Register.Application;
using Easy.Register.Application.Models.Node;

namespace Easy.Register.Controllers
{
    public class ConsumerController : Controller
    {
        // GET: Consumer
        public ActionResult Index()
        {
            IList<Node> list= ApplicationRegistry.Node.SelectByDirectoryType(1);

            ViewBag.list = list;

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