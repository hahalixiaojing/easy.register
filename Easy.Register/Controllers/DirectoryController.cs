using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Castle.Core.Internal;
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

            var r = ApplicationRegistry.Directory.Select(3);
            var model = r.DataBody;

            return View(model as IEnumerable<DirectoryModel>);
        }

        public ActionResult Add()
        {
            ViewBag.Active = "Dir";
            return View();
        }

        [HttpPost]
        public ActionResult AddPost(string name, string ip, string path, string type, string content)
        {
            var r = ApplicationRegistry.Directory.Create(name, content, ip, path, Convert.ToInt32(type));

            var model = "ok";

            if (r.Code != null)
            {
                model = r.Message;
            }
            ViewBag.Ok = model;
            return View();
        }
    }
}