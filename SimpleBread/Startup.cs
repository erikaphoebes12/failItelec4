using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SimpleBread.Startup))]
namespace SimpleBread
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
