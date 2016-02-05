using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LIFFMVC2.Startup))]
namespace LIFFMVC2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
