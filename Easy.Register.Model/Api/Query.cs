using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy.Register.Model.Api
{
    public class Query
    {
        public string Name;
        public int DirectoryId;
        public int PageIndex = 1;
        public int PageSize = 20;
    }
}
