using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy.Register.Application.Profile.CreateDomainEvents
{
    public class PushProfileSubscriber : Easy.Domain.Event.IDomainEventSubscriber<CreateDomainEvent>
    {
        public Type SuscribedToEventType
        {
            get
            {
                return typeof(CreateDomainEvent);
            }
        }

        public void HandleEvent(CreateDomainEvent aDomainEvent)
        {
            Model.ServiceRegistry.PublishService.Publish(aDomainEvent.SubscribeKey, aDomainEvent.Content);
        }
    }
}
