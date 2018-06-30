using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(proyectokevin.Startup))]
namespace proyectokevin
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
