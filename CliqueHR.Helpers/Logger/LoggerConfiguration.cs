using System;
using System.Configuration;
using System.IO;
using log4net;
using log4net.Appender;
using log4net.Config;
using log4net.Core;
using log4net.Filter;
using log4net.Layout;
using log4net.Repository;
using log4net.Repository.Hierarchy;

namespace CliqueHR.Helpers.Logger
{

    public enum LogLevel {
        Debug,
        Info,
        Warning,
        Error,
        Fatal,
        All
    }
    internal class LoggerConfiguration {
        internal ILog log;
        private PatternLayout layout;
        private LevelMatchFilter filter;
        private RollingFileAppender appender;
        private ILoggerRepository repository;
        private Hierarchy hierarchy;
        private const string RepositoryName = "my_repository";
        public LoggerConfiguration () {
            this.repository = LoggerManager.CreateRepository (RepositoryName);
            hierarchy = repository as Hierarchy;
            pattern ();
            CommonAppenderConfig ();
        }

        private void pattern () {
            layout = new PatternLayout ("%newline %date{MMM/dd/yyyy HH:mm:ss,fff} [%-5level] [Thread:%thread] %logger %newline %message %newline");
        }
        private void CommonAppenderConfig () {
            appender = new RollingFileAppender ();
            appender.ImmediateFlush = true;
            appender.AppendToFile = true;
            appender.RollingStyle = RollingFileAppender.RollingMode.Date;
            appender.DatePattern = "-yyyy - MM - dd";
            appender.LockingModel = new FileAppender.MinimalLock ();
            appender.Name = string.Format ("{0} Appender", InstanceName);
            appender.Layout = layout;
        }

        private void ActivateAppender () {
            if (string.IsNullOrEmpty (FolderPath)) {
                folderPath = Path.Combine(Directory.GetCurrentDirectory (), "Log");
            } else {
                folderPath = FolderPath;
            }
            if (!Directory.Exists (folderPath)) {
                Directory.CreateDirectory (folderPath);
            }
            appender.File = Path.Combine(folderPath, InstanceName+"-dev" +DateTime.Now.ToString("ddMMyyyy")+".log");
            appender.AddFilter (filter);
            appender.ActivateOptions ();
        }
        private void SetLevel () {
            filter = new LevelMatchFilter ();
            LogLevel level;
            if (!Enum.TryParse (Convert.ToString(ConfigurationManager.AppSettings["MyLogger.Level"]), out level)) {
                throw new Exception ("invalid level type.");
            }
            switch (level) {
                case LogLevel.Debug:
                    {
                        filter.LevelToMatch = Level.Debug;
                        break;
                    }
                case LogLevel.Error:
                    {
                        filter.LevelToMatch = Level.Error;
                        break;
                    }
                case LogLevel.Fatal:
                    {
                        filter.LevelToMatch = Level.Fatal;
                        break;
                    }
                case LogLevel.Info:
                    {
                        filter.LevelToMatch = Level.Info;
                        break;
                    }
                case LogLevel.Warning:
                    {
                        filter.LevelToMatch = Level.Warn;
                        break;
                    }
                case LogLevel.All:
                    {
                        filter.LevelToMatch = Level.All;
                        break;
                    }
            }
            filter.ActivateOptions ();
        }

        internal void Configure () {
            this.SetLevel ();
            this.ActivateAppender ();
            hierarchy.Root.AddAppender(appender);
            hierarchy.Root.Level = filter.LevelToMatch;
            hierarchy.Configured = true;
            string loggerName = string.Format ("{0}", InstanceName);
            log = LogManager.GetLogger (RepositoryName, loggerName);
        }

        private string FolderPath {
            get {
                return folderPath = Convert.ToString(ConfigurationManager.AppSettings["MyLogger.Path"]);
            }
        }

        private string folderPath;
        internal static string InstanceName { get; set; }

    }
}