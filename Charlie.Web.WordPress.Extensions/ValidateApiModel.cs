using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Controllers;


namespace Charlie.Web.WordPress
{
    public class ValidateApiModelAttribute : System.Web.Http.Filters.ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            if (!actionContext.ModelState.IsValid)
            {
                //var error = actionContext.ModelState.Aggregate("", (current, v) => current + v.Value.Value.RawValue.ToString());
                actionContext.Response =
                    actionContext.Request.CreateResponse(HttpStatusCode.BadRequest,   actionContext.ModelState.GetAllErrors());
            }
        }
    }
}
