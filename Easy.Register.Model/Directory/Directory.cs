using Easy.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy.Register.Model
{
    /// <summary>
    /// 目录
    /// </summary>
    public class Directory : EntityBase<Int32>
    {
        public Directory()
        {
            this.CreateDate = DateTime.Now;
        }
        /// <summary>
        /// 目录名称，唯一标识
        /// </summary>
        public string Name
        {
            get;
            set;
        }
        /// <summary>
        /// 描述
        /// </summary>
        public string Description
        {
            get;
            set;
        }
        /// <summary>
        /// PING API地址
        /// </summary>
        public string PingAPIPath
        {
            get;
            set;
        }
        /// <summary>
        /// 获得版本API路径
        /// </summary>
        public string VersionAPIPath
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
        /// 目录类型
        /// </summary>
        public DirectoryType DirectoryType
        {
            get;
            set;
        } 

        protected override BrokenRuleMessage GetBrokenRuleMessages()
        {
            return new DirectoryBrokenRuleMessage();
        }

        public override bool Validate()
        {
            return new DirectoryValidation().IsSatisfy(this);
        }
    }
}
