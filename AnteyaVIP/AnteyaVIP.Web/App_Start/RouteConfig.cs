using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace AnteyaVIP.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] {"AnteyaVip.Web.Controllers"}
            );

            routes.MapRoute(
                name: "Admin",
                url: "{area}/{controller}/{action}/{id}",
                defaults: new { area = "Admonistration", controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "AnteyaVIP.Web.Areas.Administration.Controllers" });
        }
    }
}
