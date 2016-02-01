using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Easy.Domain.Base;

namespace Easy.Register.Model.User
{
    class UserBrokenRuleMessage : BrokenRuleMessage
    {
        public const string UsernameIsError = "u0001";
        public const string NameIsError = "u0002";
        public const string PasswordError = "u0003";
        protected override void PopulateMessage()
        {
            this.Messages.Add(UsernameIsError, "用户名不能为空");
            this.Messages.Add(NameIsError, "名字不能为空");
            this.Messages.Add(PasswordError, "密码不能为空");
        }
    }
}
