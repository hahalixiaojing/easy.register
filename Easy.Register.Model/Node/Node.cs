using Easy.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy.Register.Model
{
    public class Node : EntityBase<Int32>
    {
        public Node()
        {
            this.Weight = 100;
            this.Status = NodeStatus.下线;
        }
        public Node(DirectoryInfo directoryInfo):this()
        {
            this.DirectoryInfo = directoryInfo;
            this.CreateDate = DateTime.Now;
        }
        /// <summary>
        /// API地址
        /// </summary>
        public string Url
        {
            get;
            set;
        }
        /// <summary>
        /// IP地址
        /// </summary>
        public string Ip
        {
            get;
            set;
        }
        /// <summary>
        /// 节点描述
        /// </summary>
        public string Description
        {
            get;
            set;
        }
        /// <summary>
        /// 权重
        /// </summary>
        public int Weight
        {
            get;
            set;
        }
        /// <summary>
        /// 状态
        /// </summary>
        public NodeStatus Status
        {
            get;
            set;
        }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateDate
        {
            get;
            private set;
        }
        /// <summary>
        /// 所属目录
        /// </summary>
        public DirectoryInfo DirectoryInfo
        {
            get;
            set;
        }

        protected override BrokenRuleMessage GetBrokenRuleMessages()
        {
            return new NodeBrokenRuleMessage();
        }

        public override bool Validate()
        {
            return new NodeValidation().IsSatisfy(this);
        }
    }
}
