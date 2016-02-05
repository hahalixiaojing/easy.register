using System;
using System.Configuration;
using Easy.Rpc.directory;

namespace Demo.Provider
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
                Description = "Demo提供者",
                Directory = "DemoProvider",
                Ip = "127.0.0.1:4001",
                Status = 1,
                Url = "http://127.0.0.1:4001",
                Weight = 100
            };

            builder.Build(myselfInfo, new string[0], new string[2] { "test/api1", "test/api2" });

            Console.ReadLine();



        }
    }
}
