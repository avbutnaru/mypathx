using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MyPathX.Web.Startup))]
namespace MyPathX.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
