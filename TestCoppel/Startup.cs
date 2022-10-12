using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TestCoppel.Startup))]
namespace TestCoppel
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
