using SportsStore.Domain.Abstract;
using SportsStore.WebUI.Infrustracture.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SportsStore.WebUI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            GlobalConfig.InitializeConnection(true);
            MainGlobal.InitializeConnection(true);

            //routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //routes.MapRoute(null, "",
            //        new
            //        {
            //            Controller = "Product",
            //            action = "List",
            //            category = (string)null,
            //            page = 1
            //        }
            //    );

            //routes.MapRoute(null, "Page{page}",
            //    new { controller = "Product", action = "List", category = (string)null },
            //    new { page = @"\d+" }
            //);

            //routes.MapRoute(null,
            //    "{ category}",
            //    new { controller = "Product", action = "List", page = 1 }
            //    );

            //routes.MapRoute(null,
            //    "{category}/Page{page}",
            //    new { cotroller = "Product", action = "List" },
            //    new { page = @"\d+" }
            //    );

            routes.MapMvcAttributeRoutes();

            routes.MapRoute(name: "Default", url: "{controller}/{action}/{id}", defaults:
                new { controller = "Product", action = "List", id = UrlParameter.Optional });
        }
    }
}
