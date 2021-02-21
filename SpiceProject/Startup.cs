using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SpiceProject.Startup))]
namespace SpiceProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
