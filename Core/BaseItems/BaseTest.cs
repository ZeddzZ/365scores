using Core.Configuration;
using log4net;
using log4net.Config;
using NUnit.Framework;
using Utilities;

namespace Core.BaseItems
{
	[TestFixture, Parallelizable(ParallelScope.All)]
	public abstract class BaseTest
	{
		protected ILog Logger => LogManager.GetLogger(GetType());
		protected TestDataSection Configuration => TestConfiguration.Configuration;

		[SetUp]
		public void BeforeBaseTest()
		{
			//Setting up Logger to use configuration from app.config
			XmlConfigurator.Configure();
			Logger.Info($"Starting execution of test {TestHelper.GetTestName()}");

		}

		[TearDown]
		public void AfterBaseTest()
		{
			Logger.Info($"Finishing execution of test {TestHelper.GetTestName()}. The result is {TestHelper.GetTestResultStatus()}");
		}
	}
}
