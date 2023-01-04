using System.Configuration;
using Utilities;

namespace Core.Configuration
{
	public class Environment : ConfigurationElement
	{
		[ConfigurationProperty("type", IsRequired = true)]
		protected string EnvironmentType => base["type"] as string;

		public EnvironmentTypes Type => EnumHelper.GetEnumValue<EnvironmentTypes>(EnvironmentType);

		[ConfigurationProperty("ui")]
		public string UiBaseUrl => base["ui"] as string;

		[ConfigurationProperty("api")]
		public string ApiBaseUrl => base["api"] as string;
	}
}
