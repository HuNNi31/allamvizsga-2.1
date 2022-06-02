using System.Web.Mvc;
using System.Web.Routing;

namespace MVCLogin
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            RouteTable.Routes.Ignore("{*pathInfo}", new { pathInfo = @"^.*(ChartImg.axd)$" });
            RouteTable.Routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            RouteTable.Routes.IgnoreRoute("{a}/{resource}.axd/{*pathInfo}");
            RouteTable.Routes.IgnoreRoute("{a}/{b}/{resource}.axd/{*pathInfo}");
            RouteTable.Routes.IgnoreRoute("{a}/{b}/{c}/{resource}.axd/{*pathInfo}");
            RouteTable.Routes.IgnoreRoute("{a}/{b}/{c}/{d}/{resource}.axd/{*pathInfo}");
        }
    }
}
