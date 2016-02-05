using System;

namespace Easy.Register.Application.Node.AddDomainEvents
{
    public class UpdateApiDomainEvent : Easy.Domain.Event.IDomainEvent
    {
        public UpdateApiDomainEvent()
        {
        }

        public UpdateApiDomainEvent(int directoryId, string[] apiList)
        {
            this.DirectoryId = directoryId;
            this.ApiList = apiList;
            this.OccurredOn = DateTime.Now;
        }
        public int DirectoryId
        {
            get;
            private set;
        }
        public string[] ApiList
        {
            get;private set;
        }

        public DateTime OccurredOn
        {
            get;
            private set;
        }
    }
}
