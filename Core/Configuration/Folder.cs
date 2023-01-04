using System.Configuration;

namespace Core.Configuration
{
	public class Folder : ConfigurationElement
	{
		[ConfigurationProperty("path", IsRequired = true)]
		public string FolderPath => base["path"] as string;
	}
}