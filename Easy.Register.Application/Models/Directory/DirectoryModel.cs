using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy.Register.Application.Models.Directory
{
    public class DirectoryModel
    {
        public int Id;
        /// <summary>
        /// 目录名称，唯一标识
        /// </summary>
        public string Name;
        /// <summary>
        /// 描述
        /// </summary>
        public string Description;
        /// <summary>
        /// PING API地址
        /// </summary>
        public string PingAPIPath;
        /// <summary>
        /// 获得版本API路径
        /// </summary>
        public string VersionAPIPath;
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateDate;
        /// <summary>
        /// 目录类型
        /// </summary>
        public Int32 DirectoryType;
    }
}
