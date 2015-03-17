using System.Web;
using System.Web.Mvc;

namespace Charlie.Web.WordPress
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
      
            filters.Add(new HandleErrorAttribute());
        }
    }
}
