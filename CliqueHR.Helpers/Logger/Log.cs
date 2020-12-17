using System;

namespace CliqueHR.Helpers.Logger {
    public static class Log {
        private static readonly LoggerConfiguration configuration;
        static Log(){
            configuration = new LoggerConfiguration();
        }

        public static void Debug(string name, string message, string detailMessage){
            configuration.Configure();
            if (configuration.log.IsDebugEnabled){
                configuration.log.DebugFormat("[{0}]:[Message]:{1}\n [Details]:{2}",name, message, detailMessage);
            }
        }
        public static void Info(string name, string message, string detailMessage){
            configuration.Configure();
            if (configuration.log.IsInfoEnabled){
                configuration.log.InfoFormat("[{0}]:[Message]:{1}\n [Details]:{2}",name, message, detailMessage);
            }
        }

        public static void Error(string name, string message, string detailMessage, Exception exception){
            configuration.Configure();
            if (configuration.log.IsErrorEnabled){
                configuration.log.Error(string.Format("[{0}]:[Message]:{1}\n [Details]:{2}",name, message, detailMessage), exception);
            }
        }

        public static void Fatal(string name, string message, string detailMessage, Exception exception){
            configuration.Configure();
            if (configuration.log.IsFatalEnabled){
                configuration.log.Fatal(string.Format("[{0}]:[Message]:{1}\n [Details]:{2}",name, message, detailMessage), exception);
            }
        }
    }
}