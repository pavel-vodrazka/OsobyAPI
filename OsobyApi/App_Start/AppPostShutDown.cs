using XXX;
using Serilog;

[assembly: WebActivatorEx.ApplicationShutdownMethod(typeof(AppPostShutDown), nameof(AppPostShutDown.PostApplicationShutDown))]
namespace XXX
{
    /// <summary>
    /// This runs even before global.asax Application_Start (see WebActivatorConfig)
    /// </summary>
    public class AppPostShutDown
    {
        public static void PostApplicationShutDown()
        {
            // force flushing the last "not logged" events
            Log.CloseAndFlush();
        }
    }
}