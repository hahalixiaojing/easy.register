using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Easy.Domain.Base;

namespace Easy.Register.Model.Api
{
    public class Api : IEntity<int>
    {
        public Api()
        {
        }
        public Api(string name, int directoryId, string directoryName)
        {
            this.Name = name;
            this.DirectoryId = directoryId;
            this.DirectoryName = directoryName;
        }
        public int Id
        {
            get;
            private set;
        }
        /// <summary>
        /// 目录名称
        /// </summary>
        public string DirectoryName
        {
            get;
            private set;
        }
        /// <summary>
        /// 目录ID
        /// </summary>
        public int DirectoryId
        {
            get;
            private set;
        }
        /// <summary>
        /// API路径
        /// </summary>
        public string Name
        {
            get; private set;
        }
    }
}
