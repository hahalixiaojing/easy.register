using Easy.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy.Register.Model
{
    class DirectoryBrokenRuleMessage : BrokenRuleMessage
    {
        public const string NameIsEmpty = "d00001";
        public const string NameIsExists = "d00002";

        protected override void PopulateMessage()
        {
            this.Messages.Add(NameIsEmpty, "目录名称不能为空");
            this.Messages.Add(NameIsExists, "目录名称已经存在");
        }
    }
}
