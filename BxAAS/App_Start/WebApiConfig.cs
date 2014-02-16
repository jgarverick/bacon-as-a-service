using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace BxAAS
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(
                name: "CookApi",
                routeTemplate: "bapi/cook",
                defaults: new { controller = "Bacon", action = "Post" }
            );
            config.Routes.MapHttpRoute(
                name: "PirateApi",
                routeTemplate: "bapi/yarr",
                defaults: new { controller = "Bacon", action = "GetPirate" }
            );
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "bapi/{controller}/{action}/{id}",
                defaults: new { controller="Bacon", action="Get", id = RouteParameter.Optional }
            );
        }
    }
}
