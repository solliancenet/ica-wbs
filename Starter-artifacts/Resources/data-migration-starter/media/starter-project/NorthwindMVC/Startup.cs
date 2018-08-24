using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NorthwindMVC.Startup))]

namespace NorthwindMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            this.ConfigureAuth(app);
        }
    }
}
