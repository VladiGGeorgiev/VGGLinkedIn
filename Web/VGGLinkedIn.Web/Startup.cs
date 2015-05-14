using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VGGLinkedIn.Web.Startup))]
namespace VGGLinkedIn.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
