using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(JobTrackerApp.WebMVC.Startup))]
namespace JobTrackerApp.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
