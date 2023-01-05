
using log4net;
using System.Configuration;

namespace Core.Configuration
{
	public class ConfigurationReader<T> where T: ConfigurationSection, new()
	{
		private static ILog Logger => LogManager.GetLogger(typeof(ConfigurationReader<T>));
		public static T Configuration { get; set; }

		static ConfigurationReader()
		{
			var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
			Logger.Info($"Reading configuration from {config.FilePath}");
			Configuration = config.GetSection(typeof(T).Name) as T;
		}
	}
}
