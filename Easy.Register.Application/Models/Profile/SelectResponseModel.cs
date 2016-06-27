using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Easy.Register.Model.Profile;

namespace Easy.Register.Application.Models.Profile
{
    public class SelectResponseModel
    {
        /// <summary>
        /// 配置文件内容类型
        /// </summary>
        public int ContentType { get; set; }
        /// <summary>
        /// 应用程序名称
        /// </summary>
        public string ApplicationName { get; set; }
        /// <summary>
        /// 配置名称
        /// </summary>
        public string ProfileName { get; set; }
        /// <summary>
        /// 配置文件内容
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateDate { get; set; }
        /// <summary>
        /// 最后一次新时间
        /// </summary>
        public DateTime LastUpdate { get; set; }
    }
}
