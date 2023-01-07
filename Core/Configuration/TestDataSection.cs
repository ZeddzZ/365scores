using System.Configuration;

namespace Core.Configuration
{
	public class TestDataSection : ConfigurationSection
	{
		[ConfigurationProperty("DriverConfig", IsRequired = true)]
		public DriverConfig DriverConfig => (DriverConfig)this["DriverConfig"];

		[ConfigurationProperty("EnvironmentConfig", IsRequired = true)]
		public EnvironmentConfig EnvironmentConfig => (EnvironmentConfig)this["EnvironmentConfig"];

		[ConfigurationProperty("TestResults", IsRequired = true)]
		public TestResults TestResults => (TestResults)this["TestResults"];

		[ConfigurationProperty("MessageQueues", IsRequired = false)]
		public MessageQueuesCollection AvailableQueues => (MessageQueuesCollection)this["MessageQueues"];

		[ConfigurationProperty("Databases", IsRequired = false)]
		public DatabasesCollection AvailableDatabases => (DatabasesCollection)this["Databases"];

		public WebDriverTypes CurrentDriver => DriverConfig.CurrentDriver;

		public Driver CurrentDriverConfig => DriverConfig.AvailableDrivers.First(el => el.Type == CurrentDriver);

		public EnvironmentTypes CurrentEnvironment => EnvironmentConfig.CurrentEnvironment;

		public Environment CurrentEnvironmentConfig => EnvironmentConfig.AvailableEnvironments.First(el => el.Type == CurrentEnvironment);
	}
}
