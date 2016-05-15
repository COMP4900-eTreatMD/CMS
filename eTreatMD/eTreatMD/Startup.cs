using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(eTreatMD.Startup))]
namespace eTreatMD
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
