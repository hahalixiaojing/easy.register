using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Easy.Register.Application;
using Easy.Register.Application.Models.Directory;

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

            var r = ApplicationRegistry.Directory.Select(2);
            var model = r.DataBody;

            return View(model as IEnumerable<DirectoryModel>);
        }

        [HttpPost]
        public ActionResult AddPost(int dir,string api,string ip,string description,string weight,int status)
        {
            
            return View();
        }
    }
}