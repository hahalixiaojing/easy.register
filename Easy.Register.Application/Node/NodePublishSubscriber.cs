using Easy.Register.Application.Models.Node;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy.Register.Application.Node
{
    public class NodePublishSubscriber : Easy.Domain.Event.IDomainEventSubscriber<NodeDomainEvent>
    {
        public void HandleEvent(NodeDomainEvent aDomainEvent)
        {
            if (aDomainEvent.Nodes.Count > 0)
            {
                var pushNodeList = aDomainEvent.Nodes.Select(m => new Easy.Register.Model.PublishService.Node(m.ProviderName, m.Url, m.Weight, m.IsAvailable,m.Ip));

                string providername = aDomainEvent.Nodes[0].ProviderName;
                Model.ServiceRegistry.PublishService.Publish(providername, pushNodeList.ToList());
            }
        }

        public Type SuscribedToEventType
        {
            get { return typeof(NodeDomainEvent); }
        }
    }
}
