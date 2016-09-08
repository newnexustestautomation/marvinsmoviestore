using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CheckIT.Web.Startup))]
namespace CheckIT.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
