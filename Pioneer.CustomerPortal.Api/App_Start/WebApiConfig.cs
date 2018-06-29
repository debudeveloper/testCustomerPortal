using Pioneer.CustomerPortal.Api.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Pioneer.CustomerPortal.Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
             GlobalConfiguration.Configuration.Filters.Add(new EnableTag());
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();
           
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
