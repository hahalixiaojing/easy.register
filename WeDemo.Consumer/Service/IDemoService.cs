using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeDemo.Consumer.Service
{
    public interface IDemoService
    {
        string TestCall(Easy.Rpc.InvokerContext context = null);

        string TestCall2(Easy.Rpc.InvokerContext context = null);
    }
}
