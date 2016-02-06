using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy.Register.Model.User
{
    public class UserDescriptor
    {
        public UserDescriptor(int id,string name)
        {
            this.Id = id;
            this.Name = name;
        }
        public int Id
        {
            get;private set;
        }
        public string Name
        {
            get;
            private set;
        }
    }
}
