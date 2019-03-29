using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Gestion_Asistencias.Startup))]
namespace Gestion_Asistencias
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
