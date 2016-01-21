using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy.Register.Infrastructure.Service.PublishService
{
    static class RedisDatabase
    {
        public static string RedisServer
        {
            get
            {
                return ConfigurationManager.AppSettings["redisServer"];
            }
        }
        public static int DatabaseIndex
        {
            get
            {
                return Int32.Parse(ConfigurationManager.AppSettings["databaseIndex"]);
            }
        }
    }
}
