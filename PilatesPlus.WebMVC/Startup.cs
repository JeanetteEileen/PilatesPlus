using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PilatesPlus.WebMVC.Startup))]
namespace PilatesPlus.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
