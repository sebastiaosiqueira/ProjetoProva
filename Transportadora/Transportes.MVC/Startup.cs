using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Transportes.MVC.Startup))]
namespace Transportes.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
