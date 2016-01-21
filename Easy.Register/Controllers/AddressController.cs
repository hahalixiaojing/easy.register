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
            //在拉取提供者地址信息的时候，需要触发一个事件，注册提供者和消费者提供之间的关系
            throw new NotImplementedException();
        }
        /// <summary>
        /// 节点注册
        /// </summary>
        /// <param name="directory">目录名称</param>
        /// <param name="url">API地址</param>
        /// <param name="ip">Node节点IP</param>
        /// <param name="weight">权重</param>
        /// <param name="status">状态</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Register(string directory, string url, string ip, int weight, int status)
        {
            //注册时，如果没有对应的directory，则直接注册成消费者，如果有则只注册Node
            //Directory之间需要建立关系
            throw new NotImplementedException();
        }
    }
}