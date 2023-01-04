using System.Configuration;

namespace Core.Configuration
{
	[ConfigurationCollection(typeof(Environment), AddItemName = "Environment")]
	public class EnvironmentsCollection : ConfigurationElementCollection
	{
		public Environment this[int index] => BaseGet(index) as Environment;
		
		protected override ConfigurationElement CreateNewElement()
		{
			return new Environment();
		}

		protected override object GetElementKey(ConfigurationElement element)
		{
			return ((Environment)element).Type;
		}
	}
}