using System.Web.Mvc;
using System.Web.Routing;

namespace MVCLogin
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Login", action = "Index", id = UrlParameter.Optional }
            );
            RouteTable.Routes.Ignore("{*pathInfo}", new { pathInfo = @"^.*(ChartImg.axd)$" });
            RouteTable.Routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            RouteTable.Routes.IgnoreRoute("{a}/{resource}.axd/{*pathInfo}");
            RouteTable.Routes.IgnoreRoute("{a}/{b}/{resource}.axd/{*pathInfo}");
            RouteTable.Routes.IgnoreRoute("{a}/{b}/{c}/{resource}.axd/{*pathInfo}");
            RouteTable.Routes.IgnoreRoute("{a}/{b}/{c}/{d}/{resource}.axd/{*pathInfo}");
        }
    }
}
