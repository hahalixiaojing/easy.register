using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Easy.Domain.Base;

namespace Easy.Register.Model.Profile
{
    public class ApplicationProfile : EntityBase<int>
    {
        public ApplicationProfile()
        {

        }
        public ApplicationProfile(string applicationName,string profileName,ProfileContentType type)
        {
            this.ApplicationName = applicationName;
            this.ProfileName = profileName;
            this.ContentType = type;
            this.CreateDate = DateTime.Now;
            this.LastUpdate = DateTime.Now;
        }
        /// <summary>
        /// 配置文件内容类型
        /// </summary>
        public ProfileContentType ContentType { get; private set; }
        /// <summary>
        /// 应用程序名称
        /// </summary>
        public string ApplicationName { get; private set; }
        /// <summary>
        /// 配置名称
        /// </summary>
        public string ProfileName { get; private set; }
        /// <summary>
        /// 配置文件内容
        /// </summary>
        public string Content { get; private set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateDate { get; private set; }
        /// <summary>
        /// 最后一次新时间
        /// </summary>
        public DateTime LastUpdate { get; private set; }

        /// <summary>
        /// 发布的KEY
        /// </summary>
        public string SubscribeKey
        {
            get
            {
                return this.ApplicationName + "_" + this.ProfileName;
            }
        }


        public void UpdateContent(string content)
        {
            this.Content = content;
            this.LastUpdate = DateTime.Now;
        }

        public override bool Validate()
        {
            return new ApplicationProfileValidation().IsSatisfy(this);
        }

        protected override BrokenRuleMessage GetBrokenRuleMessages()
        {
            return new ApplicationProfileBrokenRuleMessage();
        }
    }
}
