using System.Configuration;

namespace Core.Configuration
{
	[ConfigurationCollection(typeof(Queue), AddItemName = "MessageQueue")]
	public class MessageQueuesCollection : ConfigurationElementCollection, IEnumerable<Queue>
	{
		public Queue this[int index] => BaseGet(index) as Queue;
		
		protected override ConfigurationElement CreateNewElement()
		{
			return new Queue();
		}

		protected override object GetElementKey(ConfigurationElement element)
		{
			return ((Queue)element).QueueName;
		}

		public new IEnumerator<Queue> GetEnumerator()
		{
			foreach (var key in BaseGetAllKeys())
			{
				yield return (Queue)BaseGet(key);
			}
		}
	}
}