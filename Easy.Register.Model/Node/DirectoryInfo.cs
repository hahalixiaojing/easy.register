using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy.Register.Model
{
    public class DirectoryInfo
    {
        public DirectoryInfo()
        {

        }

        public DirectoryInfo(int id,string name)
        {
            this.Id = id;
            this.Name = name;
        }
        public Int32 Id
        {
            get;
            private set;
        } 
        public string Name
        {
            get;
            private set;
        }
    }
}
