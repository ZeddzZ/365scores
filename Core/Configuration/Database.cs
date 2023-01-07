using System.Configuration;

namespace Core.Configuration
{
	public class Database : ConfigurationElement
	{
		[ConfigurationProperty("dbName", IsRequired = true)]
		public string DbName => (string)base["dbName"];

		[ConfigurationProperty("connectionString", IsRequired = true)]
		public string ConnectionString => (string)base["connectionString"];

	}
}