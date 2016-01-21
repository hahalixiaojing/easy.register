using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy.Register.Application.Models.Node
{
    public class NodeDomainEvent : Easy.Domain.Event.IDomainEvent
    {
        public NodeDomainEvent()
        {

        }
        public NodeDomainEvent(string providerName, string url, int weight, bool isAvaiable)
        {
            this.ProviderName = providerName;
            this.Url = url;
            this.Weight = weight;
            this.IsAvailable = isAvaiable;
            this.OccurredOn = DateTime.Now;
        }

        public String ProviderName
        {
            get;
            private set;
        }
        public String Url
        {
            get;
            private set;
        }
        public Int32 Weight
        {
            get;
            private set;
        }
        public Boolean IsAvailable
        {
            get;
            private set;
        }

        public DateTime OccurredOn
        {
            get;
            private set;
        }
    }
}
