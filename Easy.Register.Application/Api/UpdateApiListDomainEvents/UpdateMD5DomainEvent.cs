using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy.Register.Application.Api.UpdateApiListDomainEvents
{
    public class UpdateMD5DomainEvent:Easy.Domain.Event.IDomainEvent
    {
        public UpdateMD5DomainEvent()
        {

        }

        public UpdateMD5DomainEvent(int directoryId,string md5)
        {
            this.DirectoryId = directoryId;
            this.Md5 = md5;
            this.OccurredOn = DateTime.Now;
        }

        public int DirectoryId
        {
            get;private set;
        }
        public string Md5
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
