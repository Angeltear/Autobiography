using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Autobiography.Startup))]
namespace Autobiography
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
