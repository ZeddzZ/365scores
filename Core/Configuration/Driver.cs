using System.Configuration;
using Utilities;

namespace Core.Configuration
{
	public class Driver : ConfigurationElement
	{
		[ConfigurationProperty("type", IsRequired = true)]
		protected string DriverType => base["type"] as string;

		public WebDriverTypes Type => EnumHelper.GetEnumValue<WebDriverTypes>(DriverType);

		[ConfigurationProperty("timeout")]
		protected string DriverTimeout => base["timeout"] as string;

		public TimeSpan Timeout => TimeSpan.Parse(DriverTimeout);

		[ConfigurationProperty("url", IsRequired = false)]
		public string Url => base["url"] as string;
	}
}