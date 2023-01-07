using System.Configuration;

namespace Core.Configuration
{
	[ConfigurationCollection(typeof(Database), AddItemName = "Database")]
	public class DatabasesCollection : ConfigurationElementCollection, IEnumerable<Database>
	{
		public Database this[int index] => (Database)BaseGet(index);
		
		protected override ConfigurationElement CreateNewElement()
		{
			return new Database();
		}

		protected override object GetElementKey(ConfigurationElement element)
		{
			return ((Database)element).DbName;
		}

		public new IEnumerator<Database> GetEnumerator()
		{
			foreach (var key in BaseGetAllKeys())
			{
				yield return (Database)BaseGet(key);
			}
		}
	}
}