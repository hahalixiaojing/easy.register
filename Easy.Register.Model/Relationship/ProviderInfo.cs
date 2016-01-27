using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy.Register.Model
{
    public class ProviderInfo 
    {
        public ProviderInfo()
        {

        }
        public ProviderInfo(string name, int directoryId)
        {
            this.ProviderName = name;
            this.ProviderDirectoryId = directoryId;
        }

        /// <summary>
        /// 目录名称
        /// </summary>
        public string ProviderName
        {
            get;
            private set;
        }
        /// <summary>
        /// 目录ID
        /// </summary>
        public int ProviderDirectoryId
        {
            get;
            private set;
        }
    }
}
