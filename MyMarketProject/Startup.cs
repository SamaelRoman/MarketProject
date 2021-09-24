using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MyMarketProject.Startup))]
namespace MyMarketProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
