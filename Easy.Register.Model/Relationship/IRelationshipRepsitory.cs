﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Easy.Domain.RepositoryFramework;

namespace Easy.Register.Model
{
    public interface IRelationshipRepsitory 
    {
        /// <summary>
        /// 添加关系
        /// </summary>
        /// <param name="relationship"></param>
        void Add(Relationship relationship);

        /// <summary>
        /// 查询所有
        /// </summary>
        /// <returns></returns>
        IEnumerable<Relationship> SelectAll();

        /// <summary>
        /// 移除消费者的关系
        /// </summary>
        /// <param name="consumerDirectoryId"></param>
        void Remove(int consumerDirectoryId);

        /// <summary>
        /// 查询消费者的关系
        /// </summary>
        /// <param name="consumerDirectoryId"></param>
        /// <returns></returns>
        IEnumerable<Relationship> Select(int consumerDirectoryId);

        /// <summary>
        /// 对应关系是否存在
        /// </summary>
        /// <param name="providerDirectoryId">提供者ID</param>
        /// <param name="consumerDirectoryId">消费者ID</param>
        /// <returns></returns>
        Boolean RelationIsExists(int providerDirectoryId, int consumerDirectoryId);

        /// <summary>
        /// 移除全部，测试时使用
        /// </summary>
        void RemoveAll();
        /// <summary>
        /// 批量添加关系
        /// </summary>
        /// <param name="list"></param>
        void Add(IList<Relationship> list);
    }
}
