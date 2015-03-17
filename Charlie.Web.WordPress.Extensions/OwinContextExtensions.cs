using System;
using System.Diagnostics;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using Microsoft.Owin;

namespace Charlie.Web.WordPress
{
    /// <summary>
    /// 
    /// </summary>
    public static class OwinContextExtensions
    {
        /// <summary>
        /// Gets the owin.
        /// </summary>
        /// <param name="controller">The controller.</param>
        /// <returns></returns>
        public static IOwinContext GetOwin(this ApiController controller)
        {
            return controller.Request.GetOwinContext();
        }

        /// <summary>
        /// Gets the owin.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns></returns>
        public static IOwinContext GetOwin(this HttpContext context)
        {
            return context.Request.GetOwinContext();
        }

        private const string IdentityKeyPrefix = "AspNet.Identity.Owin:";

        private static string GetKey(Type t)
        {
            return IdentityKeyPrefix + t.AssemblyQualifiedName;
        }
        /// <summary>
        /// Gets the specified context.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="context">The context.</param>
        /// <returns></returns>
        public static T Get<T>(this IOwinContext context)
        {
            return context.Get<T>(GetKey(typeof(T)));
        }

        /// <summary>
        /// Gets the owin.
        /// </summary>
        /// <param name="controller">The controller.</param>
        /// <returns></returns>
        public static IOwinContext GetOwin(this Controller controller)
        {
            return controller.HttpContext.GetOwinContext();
        }
    }
}