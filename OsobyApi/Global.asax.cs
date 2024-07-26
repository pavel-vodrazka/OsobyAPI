using Serilog;
using System;
using System.Web;
using System.Web.Http;

namespace OsobyApi
{
    public class WebApiApplication : HttpApplication
    {
        private static readonly ILogger Logger;

        static WebApiApplication()
        {
            Logger = Log.ForContext<WebApiApplication>();
        }

        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }

        protected void Application_End(object sender, EventArgs e)
        {
            ApplicationShutdownReason shutdownReason = System.Web.Hosting.HostingEnvironment.ShutdownReason;
            Logger.Information("App is shutting down (reason = {@shutdownReason})", shutdownReason);
        }

        protected void Application_Error()
        { }
    }
}
