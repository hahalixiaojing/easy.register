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
        public ActionResult Index()
        {
            ViewBag.Active = "Pro";
            var r = ApplicationRegistry.Directory.Select(2);
            ViewBag.Dir = r.DataBody;

            var model = ApplicationRegistry.Node.SelectByDirectoryType(2);

            return View(model);
        }
        public ActionResult Update(int nodeId)
        {
            var node = ApplicationRegistry.Node.FindById(nodeId);

            return View(node);
        }
        [HttpPost]
        public ActionResult Update(int nodeId,string url, string ip, string description)
        {
            string result = ApplicationRegistry.Node.Update(nodeId, url, ip, description);
            if (string.IsNullOrEmpty(result))
            {
                ViewBag.Ok = "ok";
            }
            else
            {
                ViewBag.Ok = result;
            }
            return View("UpdateResult");
        }

        public ActionResult Add()
        {
            ViewBag.Active = "Pro";

            var r = ApplicationRegistry.Directory.Select(2);
            var model = r.DataBody;

            return View(model as IEnumerable<DirectoryModel>);
        }

        [HttpPost]
        public ActionResult AddPost(string dir, string api, string ip, string description, int weight = 10, int status = 1)
        {
            var r = ApplicationRegistry.Node.Add(dir, api, ip, description, weight, status, new string[0]);
            var model = "ok";
            if (r != null)
            {
                model = r;
            }

            ViewBag.Ok = model;

            return View();
        }
        /// <summary>
        /// 下线
        /// </summary>
        /// <param name="id"></param>
        /// <param name="selected">1=上线，2=下线</param>
        [HttpPost]
        public void OnOffLine(int[] id, int selected)
        {
            if (selected == 1)
            {
                ApplicationRegistry.Node.OnLine(id);
            }
            else if (selected == 2)
            {
                ApplicationRegistry.Node.OffLine(id);
            }
        }
        [HttpPost]
        public void SetWeight(int[] id, bool isDouble)
        {
            if (isDouble)
            {
                ApplicationRegistry.Node.DoubleWeight(id);
            }
            else
            {
                ApplicationRegistry.Node.HalfWeight(id);
            }
        }
    }
}