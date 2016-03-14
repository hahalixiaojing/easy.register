using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using Easy.Public.MyLog;
using Easy.Rpc.directory;

namespace WeDemo.Consumer
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            //string posturl = "http://localhost:8000/CollectorData/Collector";
            //Easy.Rpc.Monitor.MonitorManager.RegisterSend(new Easy.Rpc.Monitor.FileSendCollectorData());
            //Easy.Rpc.Monitor.MonitorManager.RegisterSend(new Easy.Rpc.Monitor.HttpSendCollectorData(posturl));

            //string registerUrl = ConfigurationManager.AppSettings["registerUrl"];
            //string redisServer = ConfigurationManager.AppSettings["redisServer"];
            //int redisDatabaseIndex = int.Parse(ConfigurationManager.AppSettings["redisDatabaseIndex"]);

            //RedisDirectoryBuilder builder = new RedisDirectoryBuilder(registerUrl, redisServer, redisDatabaseIndex);

            //var myselfInfo = new MySelfInfo()
            //{
            //    Description = "Web消费者",
            //    Directory = "WebConsumer",
            //    Ip = "localhost:11020",
            //    Status = 1,
            //    Url = "http://localhost:11020/",
            //    Weight = 200
            //};
            //builder.Build(myselfInfo, new string[2] { "DemoProvider", "ProviderAndConsumer" });
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            LogManager.Info("ok", "ok");
        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}