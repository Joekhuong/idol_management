using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Lodi.Startup))]
namespace Lodi
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
