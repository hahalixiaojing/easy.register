using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Easy.Domain.Event;

namespace Easy.Register.Application.Profile.UpdateDomainEvents
{
    public class UpdateDomainEvents : IDomainEvent
    {
        public UpdateDomainEvents()
        {

        }
        public UpdateDomainEvents(string content, string subscribekey) 
        {
            this.Content = content;
            this.SubscribeKey = subscribekey;
            this.OccurredOn = DateTime.Now;
        }
        public string Content
        {
            get; protected set;
        }
        public string SubscribeKey
        {
            get; protected set;
        }
        public DateTime OccurredOn
        {
            get; private set;
        }
    }
}
