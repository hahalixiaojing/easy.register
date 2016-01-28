using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy.Register.Application.Models.Node
{
    public class NodeDomainEvent : Easy.Domain.Event.IDomainEvent
    {
        public NodeDomainEvent()
        {

        }
        public NodeDomainEvent(IList<Node> nodes)
        {
            this.Nodes = nodes;
            this.OccurredOn = DateTime.Now;
        }

        public IList<Node> Nodes
        {
            get; private set;
        }

        public DateTime OccurredOn
        {
            get;
            private set;
        }
    }
}
