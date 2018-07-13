using Microsoft.Owin;
using Owin;
using Security.WebSite.Old;

[assembly: OwinStartup(typeof(Startup))]
namespace Security.WebSite.Old
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
