using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Easy.Domain.Base;

namespace Easy.Register.Model.User
{
    /// <summary>
    /// 用户
    /// </summary>
    public class User : EntityBase<int>
    {
        public User()
        {
            this.CreateDate = DateTime.Now;
        }
        /// <summary>
        /// 账号
        /// </summary>
        public string Username
        {
            get; set;
        }
        /// <summary>
        /// 真实姓名
        /// </summary>
        public string Name
        {
            get; set;
        }
        /// <summary>
        /// 密码
        /// </summary>
        public string Password
        {
            get; set;
        }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateDate
        {
            get;private set;
        }

        protected override BrokenRuleMessage GetBrokenRuleMessages()
        {
            return new UserBrokenRuleMessage();
        }

        public override bool Validate()
        {
            return new UserValidation().IsSatisfy(this);
        }
    }
}
