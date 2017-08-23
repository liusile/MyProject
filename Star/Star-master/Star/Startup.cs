using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Star.Startup))]
namespace Star
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
