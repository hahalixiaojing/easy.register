using System;
using System.Collections.Generic;
using Easy.Domain.Application;
using Easy.Register.Application.Models.Node;
using System.Linq;
using Easy.Register.Application.Node.AddDomainEvents;

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
        public string Add(string directoryName, string url, string ip, string description, int weight, int status,string[] apiList)
        {
            var directory = Model.RepositoryRegistry.Directory.FindBy(directoryName);
            if (directory == null)
            {
                return "目录不存在";
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
            }
            this.PublishEvent("Add", new UpdateApiDomainEvent(directory.Id, apiList));

            if(node.GetBrokenRules().Count > 0)
            {
                return node.GetBrokenRules()[0].Description;
            }
            return string.Empty;
        }
        /// <summary>
        /// 编辑节点
        /// </summary>
        /// <param name="id">节点ID</param>
        /// <param name="url">API地址</param>
        /// <param name="ip">ip地址</param>
        /// <param name="description">描述</param>
        public string Update(int id,string url, string ip, string description)
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
                return string.Empty;
            }
            return node.GetBrokenRules()[0].Description;
        }
        /// <summary>
        /// 批量倍权
        /// </summary>
        /// <param name="ids">节点ID</param>
        public void DoubleWeight(int[] ids)
        {
            var nodes = Model.RepositoryRegistry.Node.FindByIds(ids);
            nodes = nodes.Select(m => { m.Weight = m.Weight * 2; return m; });

            nodes.AsParallel().ForAll((n) =>
            {
                Model.RepositoryRegistry.Node.Update(n);
            });

            int[] directoryIds = nodes.Select(m => m.DirectoryInfo.Id).Distinct().ToArray();
            this.PublishEvent(directoryIds, "DoubleWeight");
        }
        /// <summary>
        /// 批量半权
        /// </summary>
        /// <param name="ids">节点ID</param>
        public void HalfWeight(int[] ids)
        {
            var nodes = Model.RepositoryRegistry.Node.FindByIds(ids);
            nodes = nodes.Select(m => { m.Weight = (int)(m.Weight * 0.5); return m; });
            nodes.AsParallel().ForAll((n) =>
            {
                Model.RepositoryRegistry.Node.Update(n);
            });

            int[] directoryIds = nodes.Select(m => m.DirectoryInfo.Id).Distinct().ToArray();
            this.PublishEvent(directoryIds, "HalfWeight");
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
        public void OffLine(int[] ids)
        {
            var nodeList = Model.RepositoryRegistry.Node.FindByIds(ids);
            nodeList.AsParallel().ForAll((n) =>
            {
                n.Status = Model.NodeStatus.下线;
                Model.RepositoryRegistry.Node.Update(n);
            });

            var directoryIds = nodeList.Select(m => m.DirectoryInfo.Id).Distinct().ToArray();
            this.PublishEvent(directoryIds, "OffLine");
        }
        /// <summary>
        /// 上线节点
        /// </summary>
        /// <param name="ids"></param>
        public void OnLine(int[] ids)
        {
            var nodeList = Model.RepositoryRegistry.Node.FindByIds(ids);

            nodeList.AsParallel().ForAll((n) =>
            {
                n.Status = Model.NodeStatus.在线;
                Model.RepositoryRegistry.Node.Update(n);
            });

            var directoryIds = nodeList.Select(m => m.DirectoryInfo.Id).Distinct().ToArray();
            this.PublishEvent(directoryIds, "OnLine");

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
        /// <summary>
        /// 根据ID查询节点ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Models.Node.Node FindById(int id)
        {
            var m = Model.RepositoryRegistry.Node.FindBy(id);

            if (m == null)
            {
                return null;
            }

            return new Models.Node.Node(m.Id, m.DirectoryInfo.Id, m.DirectoryInfo.Name, m.Ip, m.Url, m.Weight, m.Status == Model.NodeStatus.在线,m.Description);
        }
        /// <summary>
        /// 发布
        /// </summary>
        /// <param name="directoryIds"></param>
        /// <param name="methodName"></param>
        private void PublishEvent(int[] directoryIds, string methodName)
        {
            foreach (var directoryId in directoryIds)
            {
                var nodesList = Model.RepositoryRegistry.Node.Select(directoryId);
                this.PublishEvent(methodName, new NodeDomainEvent(nodesList.Select(m => m.Convert()).ToList()));
            }
        }
    }
}
