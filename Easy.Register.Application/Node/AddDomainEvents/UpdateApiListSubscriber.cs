using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Easy.Domain.Event;

namespace Easy.Register.Application.Node.AddDomainEvents
{
    public class UpdateApiListSubscriber : IDomainEventSubscriber<UpdateApiDomainEvent>
    {
        public Type SuscribedToEventType
        {
            get
            {
                return typeof(UpdateApiDomainEvent);
            }
        }

        public void HandleEvent(UpdateApiDomainEvent aDomainEvent)
        {
            var apilist = aDomainEvent.ApiList.Select(m => new Models.Api.Api()
            {
                DirectoryId = aDomainEvent.DirectoryId,
                Name = m
            }).ToArray();

            Application.ApplicationRegistry.Api.UpdateApiList(apilist);
        }
    }
}
