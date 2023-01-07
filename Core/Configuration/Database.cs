using MSMQ.Messaging;
using System.Configuration;
using Utilities;

namespace Core.Configuration
{
	public class Database : ConfigurationElement
	{
		[ConfigurationProperty("dbName", IsRequired = true)]
		public string DbName => base["dbName"] as string;

		[ConfigurationProperty("connectionString", IsRequired = true)]
		public string ConnectionString => base["connectionString"] as string;

	}
}