using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LaPadellaELaBeaceMVC.Startup))]
namespace LaPadellaELaBeaceMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
