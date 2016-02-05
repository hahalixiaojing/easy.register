using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Easy.Public;

namespace Easy.Register.Controllers
{
    public class AddressController : Controller
    {
        /// <summary>
        /// 消费者和提供者关系注册
        /// </summary>
        /// <param name="consumerDirectoryName">消费者名称</param>
        /// <param name="providerDirectoryName">提供者名称</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AddRelation(string consumerDirectoryName, [ModelBinder(typeof(StringArrayModelBinder))]string[] providerDirectoryNames)
        {
            Application.ApplicationRegistry.Relationship.AddRelation(StringHelper.ToString(consumerDirectoryName, ""), providerDirectoryNames);
            return Content("OK");
        }

        /// <summary>
        /// 拉取指定目录的Node节点地址
        /// </summary>
        /// <param name="directory">提供者目录名称</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Pull(string providerDirectory)
        {
            var list = Application.ApplicationRegistry.Node.Select(StringHelper.ToString(providerDirectory, ""));
            return Json(list);
        }
        /// <summary>
        /// 节点注册
        /// </summary>
        /// <param name="directory">目录名称</param>
        /// <param name="url">API地址</param>
        /// <param name="ip">Node节点IP</param>
        /// <param name="weight">权重</param>
        /// <param name="status">状态</param>
        /// <param name="description">描述</param>
        /// <param name="apiList">提供者API列表，如果只是消费者没有apilist</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Register(string directory, string url, string ip, int weight, int status, string description, [ModelBinder(typeof(StringArrayModelBinder))]string[] apiList)
        {
            Application.ApplicationRegistry.Node.Add(StringHelper.ToString(directory, ""), url, ip, description, weight, status,apiList);
            return Content("OK");
        }
        /// <summary>
        /// 自动下线
        /// </summary>
        /// <param name="directoryName">目录名称</param>
        /// <param name="ip">ip地址(含端口) 如：192.168.1.1:3000</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Offline(string directoryName,string ip)
        {
            Application.ApplicationRegistry.Node.AutoOffLine(StringHelper.ToString(directoryName, ""), ip);
            return Content("OK");
        }
    }
}