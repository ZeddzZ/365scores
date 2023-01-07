using Core.BaseItems;
using NUnit.Framework;
using OpenQA.Selenium;
using Utilities;
using WebDriver = Core.WebDriver.WebDriver;

namespace UiTests
{
	[TestFixture]
	public abstract class UiBaseTest : BaseTest
	{
		protected IWebDriver Driver => WebDriver.GetDriver(TestName);

		[SetUp]
		public void BeforeUiTest()
		{
			WebDriver.RemoveDriver(TestName);
			WebDriver.CreateDriver(TestName);
		}

		[TearDown]
		public void AfterUiTest()
		{
			var screenshotFolder = Path.Combine(CurrentTestFolder, TestResult.ToString());
			FileHelper.CreateFolder(screenshotFolder);
			var screenshotFullPath = FileHelper.CreateScreenshotName(screenshotFolder);
			var screenshot = WebDriverHelper.TakeScreenshot(WebDriver.GetDriver(TestName));
			Logger.Info($"Saving screenshot to '{screenshotFullPath}'");
			screenshot.SaveAsFile(screenshotFullPath);
			TestContext.AddTestAttachment(screenshotFullPath);
			WebDriver.RemoveDriver(TestName);
		}
	}
}
