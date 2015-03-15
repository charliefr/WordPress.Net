using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Charlie.Web.WordPress.Startup))]
namespace Charlie.Web.WordPress
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
