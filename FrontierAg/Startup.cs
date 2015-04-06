using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FrontierAg.Startup))]
namespace FrontierAg
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
