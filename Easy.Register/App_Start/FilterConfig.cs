using System.Web;
using System.Web.Mvc;

namespace Easy.Register
{
    /// <summary>
    /// MVC过滤器配置
    /// </summary>
    public class FilterConfig
    {
        /// <summary>
        /// 注册过滤器
        /// </summary>
        /// <param name="filters"></param>
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            //filters.Add(new ErrorAttribute());
        }
    }
}