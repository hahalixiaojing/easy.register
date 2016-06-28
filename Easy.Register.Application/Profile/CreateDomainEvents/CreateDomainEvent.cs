using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Easy.Domain.Event;

namespace Easy.Register.Application.Profile.CreateDomainEvents
{
    public class CreateDomainEvent : IDomainEvent
    {
        public CreateDomainEvent()
        {

        }
        public CreateDomainEvent(string cotnent,string subscribeKey)
        {
            this.Content = cotnent;
            this.SubscribeKey = subscribeKey;
            this.OccurredOn = DateTime.Now;
        }

        public string Content
        {
            get;protected set;
        }
        public string SubscribeKey
        {
            get;protected set;
        }

        public DateTime OccurredOn
        {
            get; private set;
        }
    }
}
