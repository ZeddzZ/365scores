using System.Configuration;

namespace Core.Configuration
{
	public class TestDataSection : ConfigurationSection
	{
		[ConfigurationProperty("DriverConfig", IsRequired = true)]
		public DriverConfig DriverConfig => this["DriverConfig"] as DriverConfig;

		[ConfigurationProperty("EnvironmentConfig", IsRequired = true)]
		public EnvironmentConfig EnvironmentConfig => this["EnvironmentConfig"] as EnvironmentConfig;

		[ConfigurationProperty("TestResults", IsRequired = true)]
		public TestResults TestResults => this["TestResults"] as TestResults;

		[ConfigurationProperty("MessageQueues", IsRequired = false)]
		public MessageQueuesCollection AvailableQueues => this["MessageQueues"] as MessageQueuesCollection;

		[ConfigurationProperty("Databases", IsRequired = false)]
		public DatabasesCollection AvailableDatabases => this["Databases"] as DatabasesCollection;

		public WebDriverTypes CurrentDriver => DriverConfig.CurrentDriver;
		public Driver CurrentDriverConfig => DriverConfig.AvailableDrivers.First(el => el.Type == CurrentDriver);

		public EnvironmentTypes CurrentEnvironment => EnvironmentConfig.CurrentEnvironment;
		public Environment CurrentEnvironmentConfig => EnvironmentConfig.AvailableEnvironments.First(el => el.Type == CurrentEnvironment);
	}
}
