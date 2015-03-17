using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web;
 
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Charlie.Web.WordPress.Config;

namespace Charlie.Web.WordPress
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //System.Web.Helpers. AntiForgeryConfig.AdditionalDataProvider
            WebConfig.Initialize();
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            GlobalConfiguration.Configuration.Filters.Add(new ValidateApiModelAttribute());
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            QueryStringMapping jsonMapping = new QueryStringMapping("type", "json", "application/json");
            GlobalConfiguration.Configuration.Formatters.JsonFormatter.MediaTypeMappings.Add(jsonMapping);
        }
    }
}
