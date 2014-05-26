using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace LoopLeader
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
    name: null,
    url: "Page{page}",
    defaults: new { Controller = "Admin/DisplayAllMembers", action = "DisplayAllMembers" }
    );

            routes.MapRoute(
                name: null,
                url: "Page{page}",
                defaults: new { Controller = "Admin/DisplayAllProducts", action = "DisplayAllProducts" }
                );

            routes.MapRoute(
                name: "ProductAdminstration",
                url: "Admin/Products",
                defaults: new { controller = "Admin", action = "ProductIndex" }
            );

            routes.MapRoute(
                name: "MemberAdminstration",
                url: "Admin/Members",
                defaults: new { controller = "Admin", action = "MemberIndex" }
            );

            routes.MapRoute(
                name: "ContentAdminstration",
                url: "Admin/Content",
                defaults: new { controller = "Admin", action = "ContentIndex" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
