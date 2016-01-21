using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Castle.Components.DictionaryAdapter;
using Easy.Register.Application;
using Easy.Register.Application.Models.Relationship;

namespace Easy.Register.Controllers
{
    public class ChartController : BaseController
    {
        // GET: Chart
        public ActionResult Index()
        {
            ViewBag.Active = "Cha";
            return View();
        }

        public ActionResult GetRelation()
        {
            //List<Relation> relations = new List<Relation>();
            //relations.Add(new Relation("ryan", "chen"));
            //relations.Add(new Relation("ryan", "chasdfen"));
            //return Json(relations);
            return Json(ApplicationRegistry.Relationship.GetRelations());
        }
    }
}