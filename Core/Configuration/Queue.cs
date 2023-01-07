using MSMQ.Messaging;
using System.Configuration;
using Utilities;

namespace Core.Configuration
{
	public class Queue : ConfigurationElement
	{
		[ConfigurationProperty("queueName", IsRequired = true)]
		public string QueueName => base["queueName"] as string;

		[ConfigurationProperty("path", IsRequired = true)]
		public string QueuePath => base["path"] as string;

		[ConfigurationProperty("sharedModeDenyReceive", DefaultValue = "false")]
		protected string SharedMode => base["sharedModeDenyReceive"] as string;

		[ConfigurationProperty("enableCache", DefaultValue = "false")]
		protected string Cache => base["enableCache"] as string;

		[ConfigurationProperty("accessMode", DefaultValue = "SendAndReceive")]
		protected string Access => base["accessMode"] as string;

		public bool SharedModeDenyReceive => bool.Parse(SharedMode);

		public bool EnableCache => bool.Parse(Cache);

		public QueueAccessMode AccessMode => EnumHelper.GetEnumValue<QueueAccessMode>(Access);

	}
}