using System.Configuration;
using Utilities;

namespace Core.Configuration
{
	public class EnvironmentConfig : ConfigurationElement
	{
		[ConfigurationProperty("currentEnvironment", DefaultValue = nameof(EnvironmentTypes.Prod), IsRequired = true)]
		protected string Current => base["currentEnvironment"] as string;

		public EnvironmentTypes CurrentEnvironment => EnumHelper.GetEnumValue<EnvironmentTypes>(Current);

		[ConfigurationProperty("Environments")]
		public EnvironmentsCollection AvailableEnvironments => base["Environments"] as EnvironmentsCollection;
	}
}