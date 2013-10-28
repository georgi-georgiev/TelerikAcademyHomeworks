using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Simple_MVC_Project.Startup))]
namespace Simple_MVC_Project
{
    public partial class Startup 
    {
        public void Configuration(IAppBuilder app) 
        {
            ConfigureAuth(app);
        }
    }
}
