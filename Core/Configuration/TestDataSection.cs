using System.Configuration;
using Utilities;

namespace Core.Configuration
{
	public class TestDataSection : ConfigurationSection
	{
		[ConfigurationProperty("DriverConfig", IsRequired = true)]
		public DriverConfig DriverConfig => this["DriverConfig"] as DriverConfig;

		[ConfigurationProperty("EnvironmentConfig", IsRequired = true)]
		public EnvironmentConfig EnvironmentConfig => this["EnvironmentConfig"] as EnvironmentConfig;

		[ConfigurationProperty("TestResultFolder", IsRequired = true)]
		public Folder TestResultFolder => this["TestResultFolder"] as Folder;

		public WebDriverTypes CurrentDriver => DriverConfig.CurrentDriver;

		public EnvironmentTypes CurrentEnvironment => EnvironmentConfig.CurrentEnvironment;
	}
}
