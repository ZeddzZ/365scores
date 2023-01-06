using System.Configuration;

namespace Core.Configuration
{
	public class TestResults : ConfigurationElement
	{
		[ConfigurationProperty("path", IsRequired = true)]
		public string FolderPath => base["path"] as string;

		[ConfigurationProperty("file", IsRequired = true)]
		public string LogFileName => base["file"] as string;
	}
}