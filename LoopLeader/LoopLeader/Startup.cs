using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LoopLeader.Startup))]
namespace LoopLeader
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
