using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Easy.Domain.ServiceFramework;
using Easy.Register.Model.PublishService;
using Newtonsoft.Json;
using StackExchange.Redis;

namespace Easy.Register.Infrastructure.Service.PublishService
{
    public class PushService : IPublishService, IService
    {
        readonly ConnectionMultiplexer redis;
        readonly int databaseId;
        public PushService()
        {
            redis = ConnectionMultiplexer.Connect(RedisDatabase.RedisServer);
            databaseId = RedisDatabase.DatabaseIndex;
        }
        public void Publish(string directoryName, IList<Node> nodes)
        {
            string jsonNodeData = JsonConvert.SerializeObject(nodes);
            redis.GetDatabase(this.databaseId).Publish(directoryName, jsonNodeData);
        }
        public void Subscribe(string directoryName, Action<string, string> action)
        {
            redis.GetSubscriber().Subscribe(directoryName, (c, s) =>
            {
                action(c, s);
            });
        }
    }
}
