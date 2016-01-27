using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Easy.Rpc.directory;

namespace Demo.Consumer
{
    class Program
    {
        static void Main(string[] args)
        {
            string registerUrl = ConfigurationManager.AppSettings["registerUrl"];
            string redisServer = ConfigurationManager.AppSettings["redisServer"];
            int redisDatabaseIndex = int.Parse(ConfigurationManager.AppSettings["redisDatabaseIndex"]);

            RedisDirectoryBuilder builder = new RedisDirectoryBuilder(registerUrl, redisServer, redisDatabaseIndex);

            var myselfInfo = new MySelfInfo()
            {
                Description = "Demo消费者",
                Directory = "DemoConsumer",
                Ip = "192.168.1.1:4000",
                Status = 1,
                Url = "http://192.168.1.1:3000",
                Weight = 200
            };
            builder.Build(myselfInfo, new string[2] { "DemoProvider", "ProviderAndConsumer" });
        }
    }
}
