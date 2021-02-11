using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CONEXAOQR.Startup))]
namespace CONEXAOQR
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
