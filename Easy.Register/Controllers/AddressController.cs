using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
        public ActionResult AddRelation(string consumerDirectoryName,[ModelBinder(typeof(StringArrayModelBinder))]string[] providerDirectoryName)
        {
            //TODO:注册关系时，先要删除关系再添加
            throw new NotImplementedException();
        }

        /// <summary>
        /// 拉取指定目录的Node节点地址
        /// </summary>
        /// <param name="directory">提供者目录名称</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Pull(string providerDirectory)
        {
            var list = Application.ApplicationRegistry.Node.Select(providerDirectory);
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
        /// <returns></returns>
        [HttpPost]
        public ActionResult Register(string directory, string url, string ip, int weight, int status,string description)
        {
            Application.ApplicationRegistry.Node.Add(directory, url, ip, description, weight, status);
            return Content("OK");
        }
    }
}