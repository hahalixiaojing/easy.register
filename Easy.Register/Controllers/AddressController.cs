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
        /// 拉取指定目录的Node节点地址
        /// </summary>
        /// <param name="directory">目录名称</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Pull(string directory)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 注册指定目录节点地址
        /// </summary>
        /// <param name="directory">目录名称</param>
        /// <param name="url">API地址</param>
        /// <param name="ip">Node节点IP</param>
        /// <param name="desc">描述</param>
        /// <param name="weight">权重</param>
        /// <param name="status">状态</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult ProviderRegister(string directory, string url, string ip, string desc, int weight, int status)
        {
            //注册时，如果没有对应的directory，则直接注册成消费者，如果有则只注册Node
            //Directory之间需要建立关系
            throw new NotImplementedException();
        }
        [HttpPost]
        public ActionResult ConsumerRegister(string directory, string url, string ip, string desc, int weight, int status)
        {
            throw new NotImplementedException();
        }
    }
}