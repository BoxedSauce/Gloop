using System.Web.Mvc;
using System.Web.Routing;

namespace Gloop.Config
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{*url}",
                defaults: new { controller = "Gloop", action = "Index"}
            );
        }
    }
}
