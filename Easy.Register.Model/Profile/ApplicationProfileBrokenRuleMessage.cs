using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Easy.Domain.Base;

namespace Easy.Register.Model.Profile
{
    class ApplicationProfileBrokenRuleMessage : BrokenRuleMessage
    {
        public const string ContentIsError = "content is empty";

        protected override void PopulateMessage()
        {
            this.Messages.Add(ContentIsError, "配置文件内容不能为空");
        }
    }
}
