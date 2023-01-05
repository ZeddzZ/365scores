using System.Configuration;

namespace Core.Configuration
{
	[ConfigurationCollection(typeof(Driver), AddItemName = "Driver")]
	public class DriversCollection : ConfigurationElementCollection, IEnumerable<Driver>
	{
		public Driver this[int index] => BaseGet(index) as Driver;
		
		protected override ConfigurationElement CreateNewElement()
		{
			return new Driver();
		}

		protected override object GetElementKey(ConfigurationElement element)
		{
			return ((Driver)element).Type;
		}

		public new IEnumerator<Driver> GetEnumerator()
		{
			foreach (var key in BaseGetAllKeys())
			{
				yield return (Driver)BaseGet(key);
			}
		}
	}
}