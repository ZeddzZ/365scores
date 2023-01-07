using Core.BaseItems;
using Core.Csv;
using Core.Queue;
using NUnit.Framework;

namespace TestScenarios.Other
{
	[TestFixture, Parallelizable(ParallelScope.None)]
	public class MessageQueueTests : BaseTest
	{
		protected string MessageQueueName => "PrivateQueue";
		protected MsgQueue TestMessageQueue;

		[SetUp]
		public void BeforeTest()
		{
			TestMessageQueue = new MsgQueue(Configuration.AvailableQueues.First(el => el.QueueName == MessageQueueName));
		}

		[Test]
		[TestCaseSource(nameof(MessageQueueData))]
		public void MessageQueueTest(Type type, object expectedMessage)
		{
			TestMessageQueue.SetFormatter(type);
			TestMessageQueue.SendMesage(expectedMessage);
			var receivedMessage = TestMessageQueue.ReceiveMessage<object>();
			Assert.AreEqual(expectedMessage, receivedMessage);
		}

		private static IEnumerable<TestCaseData> MessageQueueData()
		{
			var dict = new Dictionary<Type, object>
			{
				{ typeof(string), "My test message" },
				{ typeof(int), 42 },
				{ typeof(MockModel), new MockModel(new List<string> { "123", "456", "-1" }) },
			};
			foreach(var item in dict)
			{
				var tcd = new TestCaseData(item.Key, item.Value);
				tcd.SetName($"MessageQueueData_{item.Key.Name}");
				yield return tcd;
			}
		}
	}
}
