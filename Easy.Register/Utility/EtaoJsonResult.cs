 
using System;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace Easy.Register.Utility
{
    /// <summary>
    /// 
    /// </summary>
    public class EtaoJsonResult:JsonResult
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public override void ExecuteResult(ControllerContext context)
        {
            if (context == null)
                throw new ArgumentNullException("context");


            var response = context.HttpContext.Response;
            response.ContentType = !String.IsNullOrEmpty(ContentType) ? ContentType : "application/json";
            if (ContentEncoding != null)
                response.ContentEncoding = ContentEncoding;
            var serializedObject = JsonConvert.SerializeObject(Data);
            response.Write(serializedObject);
        }
    }
}