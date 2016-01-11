using Easy.Public.MyLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Easy.Register
{
    /// <summary>
    /// 错误处理
    /// </summary>
    public class ErrorAttribute : FilterAttribute, IExceptionFilter
    {
        /// <summary>
        /// 错误处理
        /// </summary>
        /// <param name="filterContext"></param>
        public void OnException(ExceptionContext filterContext)
        {
            var url = filterContext.HttpContext.Request.Url.AbsolutePath;
            var ex = filterContext.Exception;
            var request = filterContext.HttpContext.Request;

            StringBuilder sb = new StringBuilder();

            foreach (var item in filterContext.HttpContext.Request.Form.AllKeys)
            {
                sb.AppendFormat("{0}:{1}", item, request.Form[item]);
                sb.AppendLine();
            }
            sb.AppendLine(ex.Message);
            sb.AppendLine(ex.StackTrace);

            LogManager.Error(url, sb.ToString());

            filterContext.ExceptionHandled = true;
            filterContext.Result = new JsonResult() { Data = "服务器错误", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
    }
}