using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace Charlie.Web.WordPress
{
  public static  class OwinEx
    {
      public static void GetOwin(this ApiController controller)
      {
          IOwinContext context = HttpContext.Current.GetOwinContext();

      }
    }
}
