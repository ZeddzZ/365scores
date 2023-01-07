using System.Configuration;

namespace Core.Configuration
{
	[ConfigurationCollection(typeof(Environment), AddItemName = "Environment")]
	public class EnvironmentsCollection : ConfigurationElementCollection, IEnumerable<Environment>
	{
		public Environment this[int index] => (Environment)BaseGet(index);
		
		protected override ConfigurationElement CreateNewElement()
		{
			return new Environment();
		}

		protected override object GetElementKey(ConfigurationElement element)
		{
			return ((Environment)element).Type;
		}

		public new IEnumerator<Environment> GetEnumerator()
		{
			foreach (var key in BaseGetAllKeys())
			{
				yield return (Environment)BaseGet(key);
			}
		}
	}
}