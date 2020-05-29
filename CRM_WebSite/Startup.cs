using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CRM_WebSite.Startup))]
namespace CRM_WebSite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
