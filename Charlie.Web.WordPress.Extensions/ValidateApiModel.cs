using System.Net;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace Charlie.Web.WordPress
{
    /// <summary>
    /// 
    /// </summary>
    public class ValidateApiModelAttribute : ActionFilterAttribute
    {
        /// <summary>
        /// 在调用操作方法之前发生。
        /// </summary>
        /// <param name="actionContext">操作上下文。</param>
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            if (!actionContext.ModelState.IsValid)
            {
                //var error = actionContext.ModelState.Aggregate("", (current, v) => current + v.Value.Value.RawValue.ToString());
                actionContext.Response =
                    actionContext.Request.CreateResponse(HttpStatusCode.BadRequest,
                        actionContext.ModelState.GetAllErrors());
            }
        }
    }
}