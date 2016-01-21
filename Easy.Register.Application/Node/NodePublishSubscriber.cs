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
            var node = new Model.PublishService.Node(aDomainEvent.ProviderName, aDomainEvent.Url, aDomainEvent.Weight, aDomainEvent.IsAvailable);

            Model.ServiceRegistry.PublishService.Publish(aDomainEvent.ProviderName, new List<Model.PublishService.Node>() { node });
        }

        public Type SuscribedToEventType
        {
            get { return typeof(NodeDomainEvent); }
        }
    }
}
