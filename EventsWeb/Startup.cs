using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EventsWeb.Startup))]
namespace EventsWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
