using Easy.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy.Register.Model
{
    public class Relationship:IEntity<int>
    {
        public int Id
        {
            get; private set;
        }
        public Relationship()
        {

        }
        public Relationship(ConsumerInfo consumer,ProviderInfo provider)
        {
            this.ConsumerInfo = consumer;
            this.Provider = provider;
        }

        /// <summary>
        /// 消费者对象
        /// </summary>
        public ConsumerInfo ConsumerInfo
        {
            get;
            private set;
        }
        /// <summary>
        /// 提供者对象
        /// </summary>
        public ProviderInfo Provider
        {
            get;
            private set;
        }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateDate
        {
            get;private set;
        }
        
    }
}