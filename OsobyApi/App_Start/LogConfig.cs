using Serilog;
using Serilog.Events;
using SerilogWeb.Classic;
using System;

namespace OsobyApi
{
    public class LogConfig
    {
        public static void Configure()
        {
            Environment.SetEnvironmentVariable("BASEDIR", AppDomain.CurrentDomain.BaseDirectory);

            var loggerConfiguration = new LoggerConfiguration()
                .ReadFrom.AppSettings()
                .Enrich.FromLogContext()
                .Enrich.WithHttpRequestRawUrl()
                .Enrich.WithHttpRequestClientHostIP()
                .Enrich.WithHttpRequestClientHostName()
                .Enrich.WithHttpRequestId()
                .Enrich.WithHttpRequestNumber()
                .Enrich.WithHttpRequestTraceId()
                .Enrich.WithHttpRequestType()
                .Enrich.WithHttpRequestUrl()
                .Enrich.WithHttpRequestUrlReferrer()
                .Enrich.WithHttpRequestUserAgent()
                .Enrich.WithHttpSessionId()
                .Enrich.WithUserName()
                .Enrich.WithWebApiActionName()
                .Enrich.WithWebApiControllerName()
                .Enrich.WithWebApiRouteData()
                .Enrich.WithWebApiRouteTemplate();

            Log.Logger = loggerConfiguration.CreateLogger();

            SerilogWebClassic.Configure(cfg => cfg
                .UseDefaultLogger()
                .IgnoreRequestsMatching(ctx => ctx.Request.Path.StartsWith("/swagger"))
                .EnableFormDataLogging(forms => forms
                    .AtLevel(LogEventLevel.Debug)
                    .OnlyOnError()
                )
                .LogAtLevel(LogEventLevel.Information)
            );
        }
    }
}