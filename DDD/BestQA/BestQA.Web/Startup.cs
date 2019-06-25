using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BestQA.Web.Startup))]
namespace BestQA.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
