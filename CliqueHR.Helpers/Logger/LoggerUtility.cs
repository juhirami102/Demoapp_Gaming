using System.Threading;
using log4net;
using Owin;

namespace CliqueHR.Helpers.Logger
{
    public static class LoggerGlobalProperty{
        public static IAppBuilder UseLogger (this IAppBuilder app, string applicationName) {
            GlobalContext.Properties["Application"] = applicationName;
            ThreadContext.Properties["ThreadId"] = Thread.CurrentThread.ManagedThreadId;
            LoggerConfiguration.InstanceName = applicationName;
            return app;
        }
    }
}