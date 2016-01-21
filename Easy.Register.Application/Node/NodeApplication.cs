using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Easy.Domain.Application;
using Easy.Register.Application.Models.Node;

namespace Easy.Register.Application.Node
{
    public class NodeApplication : BaseApplication
    {
        /// <summary>
        /// 添加节点
        /// </summary>
        /// <param name="directoryName">目录名称</param>
        /// <param name="url">API地址</param>
        /// <param name="ip">IP地址</param>
        /// <param name="description">描述</param>
        /// <param name="weight">权重</param>
        /// <param name="status">状态</param>
        /// <param name="directoryId">所属目录</param>
        public void Add(string directoryName,string url, string ip, string description, int weight, int status)
        {
            var directory = Model.RepositoryRegistry.Directory.FindBy(directoryName);
            if (directory == null)
            {
                throw new Exception("目录不存在");
            }
            var directoryInfo =new Model.DirectoryInfo(directory.Id,directory.Name);
            var node = new Model.Node(directoryInfo);
            node.Description = description;
            node.Ip = ip;
            node.Url = url;
            node.Weight = weight;
            node.Status = (Model.NodeStatus)status;

            if (node.Validate())
            {
                Model.RepositoryRegistry.Node.Add(node);
                this.PublishEvent("Add", new NodeDomainEvent(node.DirectoryInfo.Name, node.Url, node.Weight, node.Status == Model.NodeStatus.在线));
            }
        }
        /// <summary>
        /// 编辑节点
        /// </summary>
        /// <param name="id">节点ID</param>
        /// <param name="url">API地址</param>
        /// <param name="ip">ip地址</param>
        /// <param name="description">描述</param>
        public void Update(int id, string url, string ip, string description)
        {
            var node = Model.RepositoryRegistry.Node.FindBy(id);
            if (node == null)
            {
                throw new Exception("节点不存在");
            }
            node.Url = url;
            node.Ip = ip;
            node.Description = description;
            if (node.Validate())
            {
                Model.RepositoryRegistry.Node.Update(node);
                this.PublishEvent("Update", new NodeDomainEvent(node.DirectoryInfo.Name, node.Url, node.Weight, node.Status == Model.NodeStatus.在线));
            }
        }
        /// <summary>
        /// 增加权重
        /// </summary>
        /// <param name="id"></param>
        /// <param name="weight"></param>
        public void AddWeight(int id,int weight)
        {
            var node = Model.RepositoryRegistry.Node.FindBy(id);
            if(node == null)
            {
                return;
            }
            node.Weight = weight;
            Model.RepositoryRegistry.Node.Update(node);
            this.PublishEvent("AddWeight", new NodeDomainEvent(node.DirectoryInfo.Name, node.Url, node.Weight, node.Status == Model.NodeStatus.在线));
        }
        /// <summary>
        /// 减少权重
        /// </summary>
        /// <param name="id"></param>
        /// <param name="weight"></param>
        public void DecreaseWeight(int id,int weight)
        {
            var node = Model.RepositoryRegistry.Node.FindBy(id);
            if (node == null)
            {
                return;
            }
            node.Weight = weight;
            Model.RepositoryRegistry.Node.Update(node);
            this.PublishEvent("DecreaseWeight", new NodeDomainEvent(node.DirectoryInfo.Name, node.Url, node.Weight, node.Status == Model.NodeStatus.在线));
        }
        /// <summary>
        /// 下线节点
        /// </summary>
        /// <param name="id"></param>
        public void OffLine(int id)
        {
            var node = Model.RepositoryRegistry.Node.FindBy(id);
            if (node == null)
            {
                return;
            }
            node.Status = Model.NodeStatus.下线;
            Model.RepositoryRegistry.Node.Update(node);
            this.PublishEvent("OffLine", new NodeDomainEvent(node.DirectoryInfo.Name, node.Url, node.Weight, node.Status == Model.NodeStatus.在线));
        }
        /// <summary>
        /// 上线节点
        /// </summary>
        /// <param name="id"></param>
        public void OnLine(int id)
        {
            var node = Model.RepositoryRegistry.Node.FindBy(id);
            if (node == null)
            {
                return;
            }
            node.Status = Model.NodeStatus.在线;
            Model.RepositoryRegistry.Node.Update(node);
            this.PublishEvent("OnLine", new NodeDomainEvent(node.DirectoryInfo.Name, node.Url, node.Weight, node.Status == Model.NodeStatus.在线));
        }
        /// <summary>
        /// 删除节点
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
            var node = Model.RepositoryRegistry.Node.FindBy(id);
            if (node == null)
            {
                return;
            }
            if(node.Status == Model.NodeStatus.在线)
            {
                return;
            }
            Model.RepositoryRegistry.Node.Remove(node);
        }

        /// <summary>
        /// ping节点信息
        /// </summary>
        /// <param name="nodeIds"></param>
        public void Ping(int[] nodeIds)
        {

        }
        /// <summary>
        /// 获得版本号
        /// </summary>
        /// <param name="nodes"></param>
        public void Version(int[] nodes)
        {

        }
    }
}
