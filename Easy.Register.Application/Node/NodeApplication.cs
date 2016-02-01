using System;
using System.Collections.Generic;
using Easy.Domain.Application;
using Easy.Register.Application.Models.Node;
using System.Linq;
namespace Easy.Register.Application
{
    public class NodeApplication : BaseApplication
    {
        /// <summary>
        /// 添加节点或更新节点
        /// </summary>
        /// <param name="directoryName">目录名称</param>
        /// <param name="url">API地址</param>
        /// <param name="ip">IP地址</param>
        /// <param name="description">描述</param>
        /// <param name="weight">权重</param>
        /// <param name="status">状态</param>
        /// <param name="directoryId">所属目录</param>
        public string Add(string directoryName, string url, string ip, string description, int weight, int status)
        {
            var directory = Model.RepositoryRegistry.Directory.FindBy(directoryName);
            if (directory == null)
            {
                throw new Exception("目录不存在");
            }
            var directoryInfo = new Model.DirectoryInfo(directory.Id, directory.Name);

            var node = new Model.Node(directoryInfo);
            node.Description = description;
            node.Ip = ip;
            node.Url = url;
            node.Weight = weight;
            node.Status = (Model.NodeStatus)status;
            if (node.Validate())
            {
                Model.RepositoryRegistry.Node.Add(node);

                var nodes = Model.RepositoryRegistry.Node.Select(directory.Id);
                this.PublishEvent("Add", new NodeDomainEvent(nodes.Select(m => m.Convert()).ToList()));
                return null;
            }

            return node.GetBrokenRules()[0].Description;
        }
        /// <summary>
        /// 编辑节点
        /// </summary>
        /// <param name="id">节点ID</param>
        /// <param name="url">API地址</param>
        /// <param name="ip">ip地址</param>
        /// <param name="description">描述</param>
        public void Update(int id,string url, string ip, string description)
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
                var nodes = Model.RepositoryRegistry.Node.Select(node.DirectoryInfo.Id);
                this.PublishEvent("Update", new NodeDomainEvent(nodes.Select(m => m.Convert()).ToList()));
            }
        }
        /// <summary>
        /// 增加权重
        /// </summary>
        /// <param name="id"></param>
        /// <param name="weight"></param>
        public void AddWeight(int id, int weight)
        {
            var node = Model.RepositoryRegistry.Node.FindBy(id);
            if (node == null)
            {
                return;
            }
            node.Weight = weight;
            Model.RepositoryRegistry.Node.Update(node);

            var nodes = Model.RepositoryRegistry.Node.Select(node.DirectoryInfo.Id);
            this.PublishEvent("AddWeight", new NodeDomainEvent(nodes.Select(m => m.Convert()).ToList()));
        }
        /// <summary>
        /// 减少权重
        /// </summary>
        /// <param name="id"></param>
        /// <param name="weight"></param>
        public void DecreaseWeight(int id, int weight)
        {
            var node = Model.RepositoryRegistry.Node.FindBy(id);
            if (node == null)
            {
                return;
            }
            node.Weight = weight;
            Model.RepositoryRegistry.Node.Update(node);

            var nodes = Model.RepositoryRegistry.Node.Select(node.DirectoryInfo.Id);
            this.PublishEvent("DecreaseWeight", new NodeDomainEvent(nodes.Select(m => m.Convert()).ToList()));
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

            var nodes = Model.RepositoryRegistry.Node.Select(node.DirectoryInfo.Id);
            this.PublishEvent("OffLine", new NodeDomainEvent(nodes.Select(m => m.Convert()).ToList()));
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

            var nodes = Model.RepositoryRegistry.Node.Select(node.DirectoryInfo.Id);
            this.PublishEvent("OnLine", new NodeDomainEvent(nodes.Select(m => m.Convert()).ToList()));
        }
        /// <summary>
        /// 自动下线
        /// </summary>
        /// <param name="directory">目录名称</param>
        /// <param name="ip">节点IP地址(包含端口号)</param>
        public void AutoOffLine(string directoryName, string ip)
        {
            var directory = Model.RepositoryRegistry.Directory.FindBy(directoryName);
            if (directory == null)
            {
                return;
            }
            var nodelist = Model.RepositoryRegistry.Node.Select(directory.Id);
            var node = nodelist.FirstOrDefault(m => m.Ip == ip);
            if (node != null)
            {
                node.Status = Model.NodeStatus.下线;
                Model.RepositoryRegistry.Node.Update(node);

                var nodes = Model.RepositoryRegistry.Node.Select(node.DirectoryInfo.Id);
                this.PublishEvent("OffLine", new NodeDomainEvent(nodes.Select(m => m.Convert()).ToList()));
            }
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
            if (node.Status == Model.NodeStatus.在线)
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
        /// <summary>
        /// 查询目录列表
        /// </summary>
        /// <param name="directoryName"></param>
        /// <returns></returns>
        public IList<Models.Node.Node> Select(string directoryName)
        {
            var directory = Model.RepositoryRegistry.Directory.FindBy(directoryName.Trim());

            if (directory == null)
            {
                return new List<Models.Node.Node>();
            }

            var list = Model.RepositoryRegistry.Node.Select(directory.Id);
            return list.Select(m => new Models.Node.Node(m.Id, m.DirectoryInfo.Id, m.DirectoryInfo.Name, m.Ip, m.Url, m.Weight, m.Status == Model.NodeStatus.在线,m.Description)).ToArray();
        }
        /// <summary>
        ///按类型查询
        /// </summary>
        /// <param name="directoryType">1=消费者，2=提供者，3=即是提供者又是消费者</param>
        /// <returns></returns>
        public IList<Models.Node.Node> SelectByDirectoryType(int directoryType)
        {
            var directoryList = Model.RepositoryRegistry.Node.Select((Model.DirectoryType)directoryType);
            return directoryList.Select(m => new Models.Node.Node(m.Id, m.DirectoryInfo.Id, m.DirectoryInfo.Name, m.Ip, m.Url, m.Weight, m.Status == Model.NodeStatus.在线,m.Description)).ToArray();
        }

        public Models.Node.Node FindById(int id)
        {
            var m = Model.RepositoryRegistry.Node.FindBy(id);

            if (m == null)
            {
                return null;
            }

            return new Models.Node.Node(m.Id, m.DirectoryInfo.Id, m.DirectoryInfo.Name, m.Ip, m.Url, m.Weight, m.Status == Model.NodeStatus.在线,m.Description);
        }
    }
}
