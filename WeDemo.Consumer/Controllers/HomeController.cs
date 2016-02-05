using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Easy.Domain.ServiceFramework;
using WeDemo.Consumer.Service;

namespace WeDemo.Consumer.Controllers
{
    public class HomeController : Controller
    {
        static readonly ServiceFactory factory;
        static HomeController()
        {
            ServiceFactoryBuilder builder = new ServiceFactoryBuilder();
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "services.config");
            factory = builder.Build(new FileInfo(path));
        }

        // GET: Home
        public ActionResult Index()
        {

            return View();
        }

        public ActionResult CallTest()
        {
            string url = factory.Get<IDemoService>().TestCall();
            return Content(url);
        }
        public ActionResult CallTest2()
        {
            
            string url = factory.Get<IDemoService>().TestCall2();
            return Content(url+"ds");
        }
    }
}