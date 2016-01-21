using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Easy.Register
{
    /// <summary>
    /// MVC路由配置
    /// </summary>
    public class RouteConfig
    {
        /// <summary>
        /// 注册路由
        /// </summary>
        /// <param name="routes"></param>
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/",
                defaults: new { controller = "Home", action = "Index"}
            );
        }
    }
}