using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FoodManagement.Startup))]
namespace FoodManagement
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
