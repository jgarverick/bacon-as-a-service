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
                name: "DefaultApi",
                routeTemplate: "bapi/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
