using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Superheroes.Web.Startup))]
namespace Superheroes.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
