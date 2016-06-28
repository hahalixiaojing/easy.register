using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy.Register.Application.Profile.UpdateDomainEvents
{
    public class PushProfileSubscriber : Easy.Domain.Event.IDomainEventSubscriber<UpdateDomainEvents>
    {
        public Type SuscribedToEventType
        {
            get
            {
                return typeof(UpdateDomainEvents);
            }
        }

        public void HandleEvent(UpdateDomainEvents aDomainEvent)
        {
            Model.ServiceRegistry.PublishService.Publish(aDomainEvent.SubscribeKey, aDomainEvent.Content);
        }
    }
}
