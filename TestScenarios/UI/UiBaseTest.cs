using Core.BaseItems;
using Core.WebDriver;
using NUnit.Framework;
using Utilities;

namespace UiTests
{
	[TestFixture]
	public abstract class UiBaseTest : BaseTest
	{
		[SetUp]
		public void BeforeUiTest()
		{
			WebDriver.RemoveDriver(TestHelper.GetTestName());
			WebDriver.CreateDriver(TestHelper.GetTestName());
		}

		[TearDown]
		public void AfterUiTest()
		{
			var testResult = TestHelper.GetTestResultStatus();
			var screenshotFolder = Path.Combine(Configuration.TestResultFolder.FolderPath, testResult.ToString());
			FileHelper.CreateFolder(screenshotFolder);
			var screenshotFullPath = FileHelper.CreateScreenshotName(screenshotFolder);
			var screenshot = WebDriverHelper.TakeScreenshot(WebDriver.GetDriver(TestHelper.GetTestName()));
			Logger.Info($"Saving screenshot to '{screenshotFullPath}'");
			screenshot.SaveAsFile(screenshotFullPath);
			WebDriver.RemoveDriver(TestHelper.GetTestName());
		}
	}
}
