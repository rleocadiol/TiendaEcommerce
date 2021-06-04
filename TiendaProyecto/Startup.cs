using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TiendaProyecto.Startup))]
namespace TiendaProyecto
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
