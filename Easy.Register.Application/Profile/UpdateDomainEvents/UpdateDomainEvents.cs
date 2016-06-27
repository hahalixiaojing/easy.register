using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy.Register.Application.Profile.UpdateDomainEvents
{
    public class UpdateDomainEvents : CreateDomainEvents.CreateDomainEvent
    {
        public UpdateDomainEvents(string content, string subscribekey) : base(content, subscribekey)
        {

        }
    }
}
