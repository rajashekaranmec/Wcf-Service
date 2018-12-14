using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WCF_Client.Startup))]
namespace WCF_Client
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
