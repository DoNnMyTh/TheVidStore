using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TheVidStore.Startup))]
namespace TheVidStore
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
