
using System.Configuration;

namespace Core.Configuration
{
	public class ConfigurationReader<T> where T: ConfigurationSection, new()
	{
		public static T Configuration { get; set; }

		static ConfigurationReader()
		{
			Configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None).GetSection(typeof(T).Name) as T;
		}
	}
}
