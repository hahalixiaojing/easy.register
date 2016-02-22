using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using Easy.Domain.ServiceFramework;
using Easy.Rpc;
using Easy.Rpc.LoadBalance;

namespace WeDemo.Consumer.Service
{
    public class DemoService : Easy.Rpc.Protocol.IProtocol, IDemoService,IService
    {
        public T Invoke<T>(InvokerContext context = null)
        {
            throw new NotImplementedException();
        }

        public T Invoke<T>(object model, InvokerContext context = null)
        {
            throw new NotImplementedException();
        }

        public T Invoke<T>(IDictionary<string, object> queryMaps, InvokerContext context = null)
        {
            throw new NotImplementedException();
        }

        public T Invoke<T>(object model, IDictionary<string, object> queryMaps, InvokerContext context = null)
        {
            throw new NotImplementedException();
        }
        [CustomerProtocol]
        [Easy.Rpc.LoadBalance(Easy.Rpc.LoadBalance.RandomLoadBalance.NAME)]
        [Easy.Rpc.Cluster(Easy.Rpc.Cluster.FailoverCluster.NAME)]
        [Easy.Rpc.Directory("DemoProvider","/test")]
        public virtual string TestCall(InvokerContext context = null)
        {
            return Easy.Rpc.ClientInvoker.Invoke<string>(new CustomerInvoker(), context);
        }
        [CustomerProtocol]
        [Easy.Rpc.LoadBalance(Easy.Rpc.LoadBalance.RoundRobinLoadBalance.NAME)]
        [Easy.Rpc.Cluster(Easy.Rpc.Cluster.FailoverCluster.NAME)]
        [Easy.Rpc.Directory("DemoProvider", "/test2")]
        public virtual string TestCall2(Easy.Rpc.InvokerContext context = null)
        {
            return Easy.Rpc.ClientInvoker.Invoke<string>(new CustomerInvoker(), context);
        }

    }

    public class CustomerProtocol : Easy.Rpc.ProtocolAttribute
    {
        private Type type;
        public override Type ContextType
        {
            get
            {
                return typeof(Easy.Rpc.InvokerContext);
            }
            set
            {
                type = value;
            }
        }
    }

    public class CustomerInvoker : Easy.Rpc.BaseInvoker<string>
    {
        public override string JoinURL(Node node, string path)
        {
            return node.Url + path;
        }

        protected override string ActualDoInvoke(Node node, string path)
        {
            Thread.Sleep(new Random(Guid.NewGuid().GetHashCode()).Next(10, 1000));
            return this.JoinURL(node, path);
        }
    }
}