using Core.Configuration;
using log4net;
using NUnit.Framework;
using Utilities;

namespace Core.BaseItems
{
	[TestFixture]
	public abstract class BaseTest
	{
		protected ILog Logger => LogManager.GetLogger(GetType());
		protected TestDataSection Configuration => TestConfiguration.Configuration;

		[SetUp]
		public void BeforeBaseTest()
		{
			Logger.Info($"Starting execution of test {TestHelper.GetTestName()}");

		}

		[TearDown]
		public void AfterBaseTest()
		{
			Logger.Info($"Finishing execution of test {TestHelper.GetTestName()}. The result is {TestHelper.GetTestResultStatus()}");
		}
	}
}
