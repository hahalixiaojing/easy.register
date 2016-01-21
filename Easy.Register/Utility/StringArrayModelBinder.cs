using Easy.Public;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace Easy.Register
{
    /// <summary>
    /// 字符串数组转换
    /// </summary>
    public class StringArrayModelBinder : IModelBinder
    {
        /// <summary>
        /// 绑定方法
        /// </summary>
        /// <param name="controllerContext"></param>
        /// <param name="bindingContext"></param>
        /// <returns></returns>
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var request = controllerContext.HttpContext.Request;

            var values = StringHelper.ToString(request[bindingContext.ModelName], String.Empty);

            if (String.IsNullOrWhiteSpace(values))
            {
                return new string[0];
            }
            return values.Trim(',', ' ').Split(',');
        }
    }
}