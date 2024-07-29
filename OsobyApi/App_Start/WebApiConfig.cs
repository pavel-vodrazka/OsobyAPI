using System.Linq;
using System.Web.Http;

namespace OsobyApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Default output is json
            config.Formatters.XmlFormatter.SupportedMediaTypes
                .Remove(config.Formatters.XmlFormatter.SupportedMediaTypes.FirstOrDefault(t => t.MediaType == "application/xml"));
            config.Formatters.XmlFormatter.SupportedMediaTypes
                .Remove(config.Formatters.XmlFormatter.SupportedMediaTypes.FirstOrDefault(t => t.MediaType == "text/xml"));

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional },
                constraints: new { id = @"^$|^\d+$" }
            );

            config.Routes.MapHttpRoute(
                name: "Error404",
                routeTemplate: "{*url}",
                defaults: new { controller = "Error", action = "Handle404" }
            );
        }
    }
}
