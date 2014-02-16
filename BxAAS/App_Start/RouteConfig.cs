using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace BxAAS
{
    public static class RouteConfig
    {
        public static void Register(RouteCollection config)
        {
            config.MapRoute(
                "ApiHelp",
                "Help",
                new { controller = "Home", action = "Help" });
            config.MapRoute(
             "PirateBacon",
             "Yarr",
             new { controller = "Bacon", action = "Pirate" });
            config.MapRoute(
                "BaconCooker",
                "Cook",
                new { controller = "Bacon", action = "Cook" });
            config.MapRoute(
                "BaconComa",
                "Coma",
                new { controller = "Bacon", action = "Coma" });
            config.MapRoute(
                "BaconFlip",
                "Flip/{flipCount}",
                new { controller = "Bacon", action = "Flip", flipCount = UrlParameter.Optional });
            config.MapRoute(
                "Default",
                "{controller}/{action}/{id}",
                new { controller="Home", action="Index", id = RouteParameter.Optional }
            );
        }
    }
}