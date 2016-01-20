﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Easy.Domain.Application;

namespace Easy.Register.Application.Node
{
    public class NodeApplication : BaseApplication
    {
        /// <summary>
        /// 添加节点
        /// </summary>
        /// <param name="url">API地址</param>
        /// <param name="ip">IP地址</param>
        /// <param name="description">描述</param>
        /// <param name="weight">权重</param>
        /// <param name="status">状态</param>
        /// <param name="directoryId">所属目录</param>
        public void Add(string url, string ip, string description, int weight, int status, int directoryId)
        {

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
            //TODO:发布事件
            //this.PublishEvent("AddWeight", string.Empty);
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
            //TODO:发布事件
            //this.PublishEvent("DecreaseWeight", string.Empty);
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
            //TODO:发布事件
            //this.PublishEvent("DecreaseWeight", string.Empty);
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
            //TODO:发布事件
            //this.PublishEvent("DecreaseWeight", string.Empty);
        }
        public void Delete(int id)
        {
            var node = Model.RepositoryRegistry.Node.FindBy(id);
            if (node == null)
            {
                return;
            }
            Model.RepositoryRegistry.Node.Remove(node);
            //TODO:发布事件
            //this.PublishEvent("DecreaseWeight", string.Empty);
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
