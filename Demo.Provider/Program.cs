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
                Ip = "127.0.0.1:4000",
                Status = 1,
                Url = "http://127.0.0.1:4000",
                Weight = 200
            };

            builder.Build(myselfInfo, new string[0]);




        }
    }
}
