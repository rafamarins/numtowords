using NLog;

namespace NumToWord.Infrastructure.Logging
{
    public static class TraceLog
    {
        public static Logger SQLLogger = LogManager.GetLogger("SQLExceptionLog");
        public static Logger AppLogger = LogManager.GetLogger("AppLog");
        public static Logger AppExLogger = LogManager.GetLogger("AppExceptionLog");

        public static void WriteAppLog(string message, params object[] args)
        {
            AppLogger.Debug(message, args);
        }

        public static void WriteAppExLog(string message, params object[] args)
        {
            AppExLogger.Error(message, args);
        }

        public static void WriteSQLExLog(string message, params object[] args)
        {
            SQLLogger.Error(message, args);
        }
    }
}
