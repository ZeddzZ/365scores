using MSMQ.Messaging;
using System.Configuration;
using Utilities;

namespace Core.Configuration
{
	public class Queue : ConfigurationElement
	{
		[ConfigurationProperty("queueName", IsRequired = true)]
		public string QueueName => (string)base["queueName"];

		[ConfigurationProperty("path", IsRequired = true)]
		public string QueuePath => (string)base["path"];

		[ConfigurationProperty("sharedModeDenyReceive", DefaultValue = "false")]
		protected string SharedMode => (string)base["sharedModeDenyReceive"];

		[ConfigurationProperty("enableCache", DefaultValue = "false")]
		protected string Cache => (string)base["enableCache"];

		[ConfigurationProperty("accessMode", DefaultValue = "SendAndReceive")]
		protected string Access => (string)base["accessMode"];

		public bool SharedModeDenyReceive => bool.Parse(SharedMode);

		public bool EnableCache => bool.Parse(Cache);

		public QueueAccessMode AccessMode => EnumHelper.GetEnumValue<QueueAccessMode>(Access);

	}
}