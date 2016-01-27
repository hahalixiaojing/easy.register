using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Easy.Rpc.directory;

namespace Demo.ProviderAndConsumer
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
                Description = "ProviderAndConsumer提供者",
                Directory = "ProviderAndConsumer",
                Ip = "127.0.0.1:4008",
                Status = 1,
                Url = "http://127.0.0.1:4008",
                Weight = 100
            };

            builder.Build(myselfInfo, new string[1] { "DemoProvider" });
        }
    }
}
