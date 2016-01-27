using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy.Register.Model
{
    public class ConsumerInfo
    {
        public ConsumerInfo()
        {

        }
        public ConsumerInfo(string name,int directoryId)
        {
            this.ConsumerName = name;
            this.ConsumerDirectoryId = directoryId;
        }
        /// <summary>
        /// 目录名称
        /// </summary>
        public string ConsumerName
        {
            get;
            private set;
        }
        /// <summary>
        /// 目录ID
        /// </summary>
        public int ConsumerDirectoryId
        {
            get;
            private set;
        }
    }
}
