using Easy.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy.Register.Model
{
    public class Relationship
    {
        public Relationship()
        {

        }
        public Relationship(ConsumerInfo consumer,ProviderInfo provider)
        {
            this.ConsumerInfo = consumer;
            this.Provider = provider;
        }

        public ConsumerInfo ConsumerInfo
        {
            get;
            private set;
        }
        public ProviderInfo Provider
        {
            get;
            set;
        }
    }
}