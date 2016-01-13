using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy.Register.Model
{
    class NodeBrokenRuleMessage:Easy.Domain.Base.BrokenRuleMessage
    {
        public const string UrlIsEmpty = "n00001";
        public const string IPIsEmpty = "n00002";
        public const string DirectoryIdError = "n00003";
        public const string NodeIsExists = "n00004";
        protected override void PopulateMessage()
        {
            this.Messages.Add(UrlIsEmpty, "地址不能为空");
            this.Messages.Add(IPIsEmpty, "IP地址不能为空");
            this.Messages.Add(DirectoryIdError, "目录ID错误");
            this.Messages.Add(NodeIsExists, "节点已经存在");
        }
    }
}
