using System.Configuration;
using Utilities;

namespace Core.Configuration
{
	public class DriverConfig : ConfigurationElement
	{
		[ConfigurationProperty("currentDriver", DefaultValue = nameof(WebDriverTypes.Chrome), IsRequired = true)]
		protected string Current => base["currentDriver"] as string;

		public WebDriverTypes CurrentDriver => EnumHelper.GetEnumValue<WebDriverTypes>(Current);

		[ConfigurationProperty("Drivers")]
		public DriversCollection AvailableDrivers => base["Drivers"] as DriversCollection;
	}
}