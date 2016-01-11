using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy.Register.Model
{
    public class ConsumerInfo
    {
        public ConsumerInfo(string name,int directoryId)
        {
            this.Name = name;
            this.DirectoryId = directoryId;
        }
        public string Name
        {
            get;
            private set;
        }
        public int DirectoryId
        {
            get;
            private set;
        }
    }
}
