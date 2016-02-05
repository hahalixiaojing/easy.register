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

        }
        public Directory(string name)
        {
            this.CreateDate = DateTime.Now;
            this.Name = name;
        }
        /// <summary>
        /// 目录名称，唯一标识
        /// </summary>
        public string Name
        {
            get;
            protected set;
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
        /// <summary>
        /// 所引用服务的MD5值
        /// </summary>
        public string UsedServiceMd5
        {
            get; set;
        }
        /// <summary>
        /// Api接口列表MD5
        /// </summary>
        public string SerivceApiMd5 { get; set; }
        

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
