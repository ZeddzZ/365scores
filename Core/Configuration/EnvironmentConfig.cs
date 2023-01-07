using System.Configuration;
using Utilities;

namespace Core.Configuration
{
	public class EnvironmentConfig : ConfigurationElement
	{
		[ConfigurationProperty("currentEnvironment", DefaultValue = nameof(EnvironmentTypes.Prod), IsRequired = true)]
		protected string Current => (string)base["currentEnvironment"];

		[ConfigurationProperty("Environments")]
		public EnvironmentsCollection AvailableEnvironments => (EnvironmentsCollection)base["Environments"];

		public EnvironmentTypes CurrentEnvironment => EnumHelper.GetEnumValue<EnvironmentTypes>(Current);
	}
}