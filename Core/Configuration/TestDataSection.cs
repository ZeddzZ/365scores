using System.Configuration;

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

		[ConfigurationProperty("MessageQueue", IsRequired = false)]
		public Queue MessageQueueConfig => this["MessageQueue"] as Queue;

		public WebDriverTypes CurrentDriver => DriverConfig.CurrentDriver;
		public Driver CurrentDriverConfig => DriverConfig.AvailableDrivers.First(el => el.Type == CurrentDriver);

		public EnvironmentTypes CurrentEnvironment => EnvironmentConfig.CurrentEnvironment;
		public Environment CurrentEnvironmentConfig => EnvironmentConfig.AvailableEnvironments.First(el => el.Type == CurrentEnvironment);
	}
}
