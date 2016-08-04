using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TMStesting.Startup))]
namespace TMStesting
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
