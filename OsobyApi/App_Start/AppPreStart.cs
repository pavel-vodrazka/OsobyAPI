using Serilog;
using XXX;


[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(AppPreStart), nameof(AppPreStart.PreApplicationStart))]
namespace XXX
{
    /// <summary>
    /// This runs even before global.asax Application_Start (see WebActivatorConfig)
    /// </summary>
    public class AppPreStart
    {
        public static void PreApplicationStart()
        {
            LogConfig.Configure();
        }
    }
}