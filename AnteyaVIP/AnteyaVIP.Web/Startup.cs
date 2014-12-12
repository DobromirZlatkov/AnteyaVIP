using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AnteyaVIP.Web.Startup))]
namespace AnteyaVIP.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
