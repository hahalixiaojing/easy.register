using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
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

        public ActionResult Index()
        {

            return View();
        }

        public  ContentResult CallTest()
        {
                string url = factory.Get<IDemoService>().TestCall2();
                return Content(Guid.NewGuid().ToString());
        }
        public ContentResult CallTest2()
        {
            string url = factory.Get<IDemoService>().TestCall2();
            return Content(Thread.CurrentThread.ManagedThreadId.ToString());
        }
    }
}