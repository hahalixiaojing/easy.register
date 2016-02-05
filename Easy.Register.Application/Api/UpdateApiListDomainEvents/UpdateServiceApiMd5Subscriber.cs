using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Easy.Domain.Event;

namespace Easy.Register.Application.Api.UpdateApiListDomainEvents
{
    public class UpdateServiceApiMd5Subscriber : IDomainEventSubscriber<UpdateMD5DomainEvent>
    {
        public Type SuscribedToEventType
        {
            get
            {
                return typeof(UpdateMD5DomainEvent);
            }
        }

        public void HandleEvent(UpdateMD5DomainEvent aDomainEvent)
        {
            Model.RepositoryRegistry.Directory.UpdateServiceApiMd5(aDomainEvent.DirectoryId, aDomainEvent.Md5);
        }
    }
}
