using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TestWebProject.Startup))]
namespace TestWebProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
