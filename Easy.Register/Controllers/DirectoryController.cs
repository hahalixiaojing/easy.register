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
        public ActionResult Index()
        {
            ViewBag.Active = "Dir";

            var r = ApplicationRegistry.Directory.FindAll();
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


        [HttpPost]
        public void updatePingAPIPath(int id, string PingAPIPath)
        {
            var r = ApplicationRegistry.Directory.FindById(id);
            if (r == null)
            {
                return;
            }

            ApplicationRegistry.Directory.Update(id, r.Description, PingAPIPath, r.VersionAPIPath, r.DirectoryType);
        }

        [HttpPost]
        public void updateVersionAPIPath(int id, string VersionAPIPath)
        {
            var r = ApplicationRegistry.Directory.FindById(id);
            if (r == null)
            {
                return;
            }

            ApplicationRegistry.Directory.Update(id, r.Description, r.PingAPIPath, VersionAPIPath, r.DirectoryType);
        }

        [HttpPost]
        public void updateType(int id, int Type)
        {
            var r = ApplicationRegistry.Directory.FindById(id);
            if (r == null)
            {
                return;
            }

            ApplicationRegistry.Directory.Update(id, r.Description, r.PingAPIPath, r.VersionAPIPath, Type);
        }

        [HttpPost]
        public void updateDescription(int id, string Description)
        {
            var r = ApplicationRegistry.Directory.FindById(id);
            if (r == null)
            {
                return;
            }

            ApplicationRegistry.Directory.Update(id, Description, r.PingAPIPath, r.VersionAPIPath, r.DirectoryType);
        }
    }
}