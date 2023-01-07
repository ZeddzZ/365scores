using log4net;
using log4net.Appender;
using log4net.Layout;

namespace Utilities
{
	public static class LoggerHelper
	{
		public static ILog GetCurrentLogger() => LogManager.GetLogger(TestHelper.GetTestFullName());

		public static FileAppender CreateFileAppender(string filePath, string messagePattern = "%date [%thread] %-5level %logger [%ndc] - %message%newline", bool append = false)
		{
			var layout = new PatternLayout(messagePattern);
			var fileAppender = new FileAppender
			{
				Layout = layout,
				File = filePath,
				AppendToFile = append
			};
			return fileAppender;
		}

		public static void AddAppender(IAppender appender)
		{
			var logger = GetCurrentLogger().Logger as log4net.Repository.Hierarchy.Logger;
			if (logger != null)
			{
				logger.AddAppender(appender);
			}
		}

		public static void DropLogger()
		{
			var logger = GetCurrentLogger();
			logger.Logger.Repository.Shutdown();
		}
	}
}
