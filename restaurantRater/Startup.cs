using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(restaurantRater.Startup))]
namespace restaurantRater
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
