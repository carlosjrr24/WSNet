using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WSNet.Startup))]
namespace WSNet
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
