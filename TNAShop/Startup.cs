using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TNAShop.Startup))]
namespace TNAShop
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            app.MapSignalR();
        }
    }
}
