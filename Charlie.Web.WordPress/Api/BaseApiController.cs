using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Charlie.Web.WordPress.Models.Messages;
using Microsoft.Owin;

namespace Charlie.Web.WordPress.Api
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class BaseApiController : ApiController
    {
        private IOwinContext _owinContext = null;
        protected HttpResponseMessage HttpResponseMessage { get; set; }

        public override Task<HttpResponseMessage> ExecuteAsync(System.Web.Http.Controllers.HttpControllerContext controllerContext, System.Threading.CancellationToken cancellationToken)
        {
            return HttpResponseMessage!=null ? Task.FromResult(HttpResponseMessage): base.ExecuteAsync(controllerContext, cancellationToken);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseApiController"/> class.
        /// </summary>
        protected BaseApiController()
        {
        
        }

        protected BaseApiController(System.Web.Mvc.Controller controller)
        {
            if (controller!=null)
            {
                _owinContext = controller.GetOwin();
            }
           
        }

        public IOwinContext OwinContext
        {
            get { return _owinContext ?? (_owinContext = this.GetOwin()); }
           protected  set { _owinContext = value; }
        }


        /// <summary>
        /// Bads the request message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        protected HttpResponseMessage BadRequestMessage(string message)
        {
          return   CreateBadRequestMessage(this, message);
        }


        /// <summary>
        /// Bads the request message.
        /// </summary>
        /// <param name="modestate">The modestate.</param>
        /// <returns></returns>
        protected  HttpResponseMessage BadRequestMessage(System.Web.Http.ModelBinding.ModelStateDictionary modestate)
        {
            this.HttpResponseMessage = CreateBadRequestMessage(this, modestate);
            return this.HttpResponseMessage;
        }

        protected HttpResponseMessage ServerExceptionMessage(string e)
        {
            this.HttpResponseMessage = CreateServerExceptionMessage(this, e);
            return this.HttpResponseMessage;
    
        }

        protected HttpResponseMessage ServerExceptionMessage(Exception e)
        {
            this.HttpResponseMessage = CreateServerExceptionMessage(this, e);
            this.OwinContext.Response.StatusCode = 401;
            this.OwinContext.Response.Write("401");
            var context = this.OwinContext.Get<System.Web.HttpContextWrapper>("System.Web.HttpContextBase");
            context.Response.Write(e.Message);
            context.Response.StatusCode = 400;
            //context.Response.Close();
            //context.Close();
            return this.HttpResponseMessage;
 
        }
        /// <summary>
        /// Creates the bad request message.
        /// </summary>
        /// <param name="controller">The controller.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public static HttpResponseMessage CreateBadRequestMessage(ApiController controller,string message)
        {
            var bad = controller.Request.CreateResponse(HttpStatusCode.BadRequest,
              ResponseStatusMessage.Failure(message));
            return bad;
        }

        /// <summary>
        /// Creates the bad request message.
        /// </summary>
        /// <param name="controller">The controller.</param>
        /// <param name="e">The Exception.</param>
        /// <returns></returns>
        public static HttpResponseMessage CreateServerExceptionMessage(ApiController controller, Exception e)
        {
 
            var errors = e is AggregateException ? ((AggregateException) (e)).GetAllErrors() : e.GetAllErrors();
            var bad = controller.Request.CreateResponse(HttpStatusCode.InternalServerError,
              ResponseStatusMessage.Failure(errors.Aggregate()));
            return bad;
        }

        /// <summary>
        /// Creates the bad request message.
        /// </summary>
        /// <param name="controller">The controller.</param>
        /// <param name="e">The Exception.</param>
        /// <returns></returns>
        public static HttpResponseMessage CreateServerExceptionMessage(ApiController controller, string e)
        {
            var bad = controller.Request.CreateResponse(HttpStatusCode.InternalServerError,
              ResponseStatusMessage.Failure(e));
            return bad;
        }
        /// <summary>
        /// Creates the bad request message.
        /// </summary>
        /// <param name="controller">The controller.</param>
        /// <param name="modestate">The modestate.</param>
        /// <returns></returns>
        public static HttpResponseMessage CreateBadRequestMessage(ApiController controller, System.Web.Http.ModelBinding.ModelStateDictionary modestate)
        {
            var message = modestate.GetAllErrors().Aggregate();
            var bad = controller.Request.CreateResponse(HttpStatusCode.BadRequest,
                ResponseStatusMessage.Failure(message));
            return bad;
        }
        }
    
}
