using Serilog;
using Serilog.Events;
using SerilogWeb.Classic;
using SerilogWeb.Classic.Enrichers;
using SerilogWeb.Classic.WebApi.Enrichers;
using System;

namespace XXX
{
    public class LogConfig
    {
        public static void Configure()
        {
            ApplicationLifecycleModule.LogPostedFormData = LogPostedFormDataOption.OnlyOnError;
            //SerilogWebClassic.Configure(cfg => cfg.EnableFormDataLogging());
            ApplicationLifecycleModule.FormDataLoggingLevel = LogEventLevel.Debug;
            //SerilogWebClassic.Configure(cfg => cfg.EnableFormDataLogging(forms => forms.AtLevel(LogEventLevel.Debug)));
            ApplicationLifecycleModule.RequestLoggingLevel = LogEventLevel.Debug;
            //SerilogWebClassic.Configure(cfg => cfg.LogAtLevel(LogEventLevel.Debug));

            Environment.SetEnvironmentVariable("BASEDIR", AppDomain.CurrentDomain.BaseDirectory);

            var loggerConfiguration = new LoggerConfiguration().ReadFrom.AppSettings()
                    .Enrich.FromLogContext()
                    .Enrich.With<HttpRequestIdEnricher>()
                    .Enrich.With<UserNameEnricher>()
                    .Enrich.With<HttpRequestUrlEnricher>()
                    .Enrich.With<WebApiRouteTemplateEnricher>()
                    .Enrich.With<WebApiControllerNameEnricher>()
                    .Enrich.With<WebApiRouteDataEnricher>()
                    .Enrich.With<WebApiActionNameEnricher>();

            Log.Logger = loggerConfiguration.CreateLogger();
        }
    }
}