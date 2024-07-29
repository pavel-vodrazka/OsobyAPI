using OsobyApi.App_Start;
using OsobyApi.Controllers;
using Serilog;
using System;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;

namespace OsobyApi
{
    public class WebApiApplication : HttpApplication
    {
        static WebApiApplication()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            GlobalConfiguration.Configuration.Services.Replace(typeof(IHttpControllerSelector), new HttpNotFoundAwareDefaultHttpControllerSelector(GlobalConfiguration.Configuration));
            GlobalConfiguration.Configuration.Services.Replace(typeof(IHttpActionSelector), new HttpNotFoundAwareControllerActionSelector());

            LogConfig.Configure();
        }

        protected void Application_Start()
        {
            AutoMapperConfig.Register();

            Log.Information("App is starting");
        }

        //protected void Application_BeginRequest()
        //{
        //    Log.Debug("{Test} - {HttpRequestUserAgent}");
        //}

        protected void Application_End(object sender, EventArgs e)
        {
            ApplicationShutdownReason shutdownReason = System.Web.Hosting.HostingEnvironment.ShutdownReason;
            Log.Information("App is shutting down (reason = {@shutdownReason})", shutdownReason);
            Log.CloseAndFlush();
        }

        protected void Application_Error()
        { }
    }
}
