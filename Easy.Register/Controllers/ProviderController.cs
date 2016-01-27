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

            var model = ApplicationRegistry.Node.SelectByDirectoryType(2);

            return View(model);
        }

        public ActionResult Add()
        {
            ViewBag.Active = "Pro";

            var r = ApplicationRegistry.Directory.Select(2);
            var model = r.DataBody;

            return View(model as IEnumerable<DirectoryModel>);
        }

        [HttpPost]
        public ActionResult AddPost(string dir, string api, string ip, string description, int weight, int status)
        {
            var r = ApplicationRegistry.Node.Add(dir, api, ip, description, weight, status);
            var model = "ok";
            if (r != null)
            {
                model = r;
            }

            ViewBag.Ok = model;

            return View();
        }

        [HttpPost]
        public void OnOffLine(int id, int selected)
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
        public void SetWeight(int id, int weight)
        {
            var r = ApplicationRegistry.Node.FindById(id);

            if (r == null)
            {
                return;
            }

            if (r.Weight > weight)
            {
                ApplicationRegistry.Node.DecreaseWeight(id,weight);
            }
            else if (r.Weight < weight)
            {
                ApplicationRegistry.Node.AddWeight(id, weight);
            }
        }
    }
}