using Microsoft.Owin;
using Owin;
using Security.WebSite;

[assembly: OwinStartup(typeof(Startup))]
namespace Security.WebSite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
