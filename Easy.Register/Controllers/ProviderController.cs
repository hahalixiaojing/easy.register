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
            var r = ApplicationRegistry.Directory.Select(2);
            ViewBag.Dir = r.DataBody;

            var model = ApplicationRegistry.Node.SelectByDirectoryType(2);

            return View(model);
        }

        [HttpPost]
        public void updateUrl(int id, string url)
        {
            var r = ApplicationRegistry.Node.FindById(id);

            ApplicationRegistry.Node.Update(id, url, r.Ip, r.Description);

        }
        [HttpPost]
        public void updateIP(int id, string IP)
        {
            var r = ApplicationRegistry.Node.FindById(id);

            ApplicationRegistry.Node.Update(id, r.Url, IP, r.Description);

        }
        [HttpPost]
        public void updateDescription(int id, string Description)
        {
            var r = ApplicationRegistry.Node.FindById(id);

            ApplicationRegistry.Node.Update(id, r.Url, r.Ip, Description);

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
            var r = ApplicationRegistry.Node.Add(dir, api, ip, description, weight, status);
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
        public void SetWeight(int id, int weight)
        {
            var r = ApplicationRegistry.Node.FindById(id);

            if (r == null)
            {
                return;
            }

            if (r.Weight > weight)
            {
                ApplicationRegistry.Node.DecreaseWeight(id, weight);
            }
            else if (r.Weight < weight)
            {
                ApplicationRegistry.Node.AddWeight(id, weight);
            }
        }
    }
}