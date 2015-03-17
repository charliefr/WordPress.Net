using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Charlie.Web.WordPress.Models.Passport;
using System.Web.Http;
using System.Web.Http.Results;
using Charlie.Web.WordPress.Data;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using System.Collections.Generic;
using System.ComponentModel;
using Microsoft.Owin.Security;
namespace Charlie.Web.WordPress.Api.Passport
{
    public class RegisterController : ApiController
    {
         private const string OwinEnvironmentKey = "MS_OwinEnvironment";
        private const string OwinContextKey = "MS_OwinContext";
        // POST: api/Register
         [HttpPost]
        public async Task<IHttpActionResult> Post([FromBody]RegisterViewModel value)
        {
            return await this.ExecutePost(value, this.Request.GetOwinContext()).ContinueWith<IHttpActionResult>(args => args.IsFaulted
                ? (IHttpActionResult) this.BadRequest(args.Exception.GetAllErrors().Aggregate())
                : this.Ok(args.Result.Id));
        }
       internal System.Threading.Tasks.Task<Data.Models.User> ExecutePost(RegisterViewModel value,  Microsoft.Owin.IOwinContext context)
        {
           this.ActionContext
            //IOwinContext context;
            //if (!this.Request.Properties.TryGetValue<IOwinContext>(OwinContextKey, out context))
           return System.Threading.Tasks.Task.Run(() => context.Get<IUserRegisterProvider>().Register(value));
        }
    }
}
