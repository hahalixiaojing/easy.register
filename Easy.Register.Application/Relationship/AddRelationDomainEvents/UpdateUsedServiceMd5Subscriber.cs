using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy.Register.Application.Relationship.AddRelationDomainEvents
{
    public class UpdateUsedServiceMd5Subscriber : Easy.Domain.Event.IDomainEventSubscriber<UpdateMD5DomainEvent>
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
            Model.RepositoryRegistry.Directory.UpdateUsedServiceMd5(aDomainEvent.DirectoryId, aDomainEvent.Md5);
        }
    }
}
