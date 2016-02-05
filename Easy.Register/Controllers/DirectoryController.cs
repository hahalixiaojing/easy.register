using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Castle.Core.Internal;
using Easy.Register.Application;
using Easy.Register.Application.Models.Directory;
using Easy.Register.Utility;

namespace Easy.Register.Controllers
{
    [WebAuthorize]
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

            if (string.IsNullOrEmpty(r))
            {
                ViewBag.Ok = "ok";
            }
            else
            {
                ViewBag.Ok = r;
            }
            return View();
        }

        public ActionResult Update(int directoryId)
        {
            var directory = ApplicationRegistry.Directory.FindById(directoryId);
            return View(directory);
        }
        [HttpPost]
        public ActionResult Update(int directoryId,string ip, string path, int type, string content)
        {
            var r = ApplicationRegistry.Directory.Update(directoryId, content, ip, path, type);
            if (string.IsNullOrEmpty(r))
            {
                ViewBag.Ok = "ok";
            }
            else
            {
                ViewBag.Ok = r;
            }
            return View("UpdateResult");

        }
    }
}