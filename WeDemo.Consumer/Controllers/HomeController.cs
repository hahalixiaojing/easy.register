using System;
using System.IO;
using System.Threading;
using System.Web.Mvc;
using Easy.Domain.ServiceFramework;

namespace WeDemo.Consumer.Controllers
{
    public class HomeController : Controller
    {
        static HomeController()
        {
           
        }
        public ActionResult Index()
        {
            return View();
        }
    }
}