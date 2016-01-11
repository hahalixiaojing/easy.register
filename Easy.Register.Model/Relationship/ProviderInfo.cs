using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy.Register.Model
{
    public class ProviderInfo : ConsumerInfo
    {
        public ProviderInfo(string name, int directoryId)
            : base(name, directoryId)
        {

        }
    }
}
