using System.Configuration;
using Utilities;

namespace Core.Configuration
{
	public class Driver : ConfigurationElement
	{
		[ConfigurationProperty("type", IsRequired = true)]
		protected string DriverType => (string)base["type"];

		public WebDriverTypes Type => EnumHelper.GetEnumValue<WebDriverTypes>(DriverType);

		[ConfigurationProperty("timeout")]
		protected string DriverTimeout => (string)base["timeout"];

		public TimeSpan Timeout => TimeSpan.Parse(DriverTimeout);

		[ConfigurationProperty("url", IsRequired = false)]
		public string Url => (string)base["url"];
	}
}