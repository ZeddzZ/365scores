using Core.Configuration;
using log4net;
using log4net.Appender;
using log4net.Config;
using NUnit.Framework;
using Utilities;

namespace Core.BaseItems
{
	[TestFixture, Parallelizable(ParallelScope.All)]
	public abstract class BaseTest
	{
		protected ILog Logger => LoggerHelper.GetCurrentLogger();
		protected TestDataSection Configuration => TestConfiguration.Configuration;
		protected string TestName => TestHelper.GetTestFullName();
		protected DateTime TestRunStart { get; private set; }
		protected string CurrentTestFolder { get; private set; }

		[SetUp]
		public void BeforeBaseTest()
		{
			TestRunStart = DateTime.Now;
			CurrentTestFolder = Path.Combine(Configuration.TestResults.FolderPath, TestRunStart.ToString("yyyy_MM_dd-hh_mm_ss"));
			FileHelper.CreateFolder(CurrentTestFolder);

			//Setting up Logger to use configuration from app.config
			XmlConfigurator.Configure();
			LoggerHelper.AddAppender(
				LoggerHelper.CreateFileAppender(Path.Combine(CurrentTestFolder, $"{TestName}.txt"))
				);

			Logger.Info($"Test results will be stored in folder '{CurrentTestFolder}'");
			Logger.Info($"Starting execution of test {TestHelper.GetTestName()}");

		}

		[TearDown]
		public void AfterBaseTest()
		{
			Logger.Info($"Finishing execution of test {TestHelper.GetTestName()}. The result is {TestHelper.GetTestResultStatus()}");
			var resultsFolder = Path.Combine(CurrentTestFolder, TestHelper.GetTestResultStatus().ToString());
			FileHelper.CreateFolder(resultsFolder);
			LoggerHelper.DropLogger();
			File.Move(Path.Combine(CurrentTestFolder, $"{TestName}.txt"), Path.Combine(CurrentTestFolder, TestHelper.GetTestResultStatus().ToString(), $"{TestName}.txt"));
		}
	}
}
