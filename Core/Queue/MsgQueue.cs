using log4net;
using MSMQ.Messaging;
using Utilities;

namespace Core.Queue
{
	public class MsgQueue
	{
		protected ILog Logger => LoggerHelper.GetCurrentLogger();

		private MessageQueue _queue;

		public MsgQueue(string path, bool sharedModeDenyReceive = false, bool enableCache = false, QueueAccessMode accessMode = QueueAccessMode.SendAndReceive)
		{
			Logger.Info($"Connecting to queue '{path}' with sharedModeDenyReceive = {sharedModeDenyReceive}, enableCache = {enableCache}, accessMode = {accessMode}");
			_queue = new MessageQueue(path, sharedModeDenyReceive, enableCache, accessMode);
		}

		public MsgQueue(Configuration.Queue queueConfig) : this(queueConfig.QueuePath, queueConfig.SharedModeDenyReceive, queueConfig.EnableCache, queueConfig.AccessMode)
		{
		}

		public void SetFormatter(params Type[] types)
		{
			_queue.Formatter = new XmlMessageFormatter(types);
		}

		public void SetFormatter(params string[] typeNames)
		{
			_queue.Formatter = new XmlMessageFormatter(typeNames);
		}

		public void SendMesage<T>(T message)
		{
			Logger.Info($"Sending message {message} to queue");
			_queue.Send(message);
		}

		public void SendMesage<T>(T message, MessageQueueTransaction? transaction = null)
		{
			Logger.Info($"Sending message {message} {(transaction != null ? $"with transaction {transaction}" : "")}  to queue");
			_queue.Send(message, transaction);
		}

		public void SendMesage<T>(T message, MessageQueueTransactionType type = MessageQueueTransactionType.None)
		{
			Logger.Info($"Sending message {message} {(type != MessageQueueTransactionType.None ? $"with transaction type {type}" : "")}  to queue");
			_queue.Send(message, type);
		}

		public T ReceiveMessage<T>()
		{
			var message = _queue.Receive();
			var messageBody = (T)message.Body;

			Logger.Info($"Received message from queue ");
			return messageBody;
		}

		public void MonitorQueue<T>()
		{
			Logger.Info($"Monitoring queue...");
			while (true)
			{
				ReceiveMessage<T>();
				//some processing
			}
		}

	}
}
