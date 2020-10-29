using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MPOS.Startup))]
namespace MPOS
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
