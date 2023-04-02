using System.Web.Mvc;
using System.Web.Routing;

namespace Northwind.WebAPI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "ShippersByCompanyName",
                url: "shippers/GetShippersByString/{companyName}",
                defaults: new { controller = "Shippers", action = "GetShippersByString", name = UrlParameter.Optional }
            );
        }
    }
}
