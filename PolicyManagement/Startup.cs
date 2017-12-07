using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PolicyManagement.Startup))]
namespace PolicyManagement
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
