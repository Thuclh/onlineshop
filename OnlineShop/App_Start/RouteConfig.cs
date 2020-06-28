using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace OnlineShop
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Category",
                url: "san-pham/{MetaTitle}-{cateId}",
                defaults: new { controller = "Product", action = "Category", id = UrlParameter.Optional },
                namespaces: new[] { "OnlineShop.Controllers" }
            );
           
            routes.MapRoute(
                name: "ProductDetail",
                url: "chi-tiet/{MetaTitle}-{id}",
                defaults: new { controller = "Product", action = "Detail", id = UrlParameter.Optional },
                namespaces: new[] { "OnlineShop.Controllers" }
            );

            routes.MapRoute(
               name: "About",
               url: "gioi-thieu",
               defaults: new { controller = "About", action = "Index", id = UrlParameter.Optional },
               namespaces: new[] { "OnlineShop.Controllers" }
           );

            routes.MapRoute(
               name: "News",
               url: "tin-tuc",
               defaults: new { controller = "News", action = "Index", id = UrlParameter.Optional },
               namespaces: new[] { "OnlineShop.Controllers" }
           );

            routes.MapRoute(
              name: "Product",
              url: "san-pham",
              defaults: new { controller = "Product", action = "Index", id = UrlParameter.Optional },
              namespaces: new[] { "OnlineShop.Controllers" }
          );

            routes.MapRoute(
               name: "Contact",
               url: "lien-he",
               defaults: new { controller = "Contact", action = "Index", id = UrlParameter.Optional },
               namespaces: new[] { "OnlineShop.Controllers" }
           );
            routes.MapRoute(
               name: "Add Cart",
               url: "them-gio-hang",
               defaults: new { controller = "Cart", action = "AddItem", id = UrlParameter.Optional },
               namespaces: new[] { "OnlineShop.Controllers" }
           );
            routes.MapRoute(
               name: "Register",
               url: "dang-ky",
               defaults: new { controller = "User", action = "Register", id = UrlParameter.Optional },
               namespaces: new[] { "OnlineShop.Controllers" }
           );
            routes.MapRoute(
               name: "Cart",
               url: "gio-hang",
               defaults: new { controller = "Cart", action = "Index", id = UrlParameter.Optional },
               namespaces: new[] { "OnlineShop.Controllers" }
           );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }, 
                namespaces: new[] { "OnlineShop.Controllers" }
            );
        }
    }
}
