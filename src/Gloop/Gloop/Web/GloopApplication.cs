using System.Web.Routing;
using Gloop.Config;

namespace Gloop.Web
{
    public class GloopApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            OnApplicationStarted();
        }

        protected virtual void OnApplicationStarted() { }
    }
}
