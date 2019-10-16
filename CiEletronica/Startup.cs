using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CiEletronica.Startup))]
namespace CiEletronica
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
