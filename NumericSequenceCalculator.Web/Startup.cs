using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NumericSequenceCalculator.Web.Startup))]
namespace NumericSequenceCalculator.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
