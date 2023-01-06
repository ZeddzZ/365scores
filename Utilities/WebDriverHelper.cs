using log4net;
using OpenQA.Selenium;

namespace Utilities
{
	public static class WebDriverHelper
	{
		private static ILog Logger => LoggerHelper.GetCurrentLogger();

		public static object ExecuteJs(this IWebDriver driver, string script, params object[] args)
		{
			Logger.Info($"Executing JS script '{script}' with arguments '{string.Join(" ,", args)}'");
			var jsDriver = driver as IJavaScriptExecutor;
			return jsDriver.ExecuteScript(script, args);
		}

		public static void JsClick(this IWebDriver driver, IWebElement element)
		{
			ExecuteJs(driver, "arguments[0].click();", element);
		}

		public static Screenshot TakeScreenshot(this IWebDriver driver)
		{
			Logger.Info($"Creating screenshot of web page");
			var scr = driver as ITakesScreenshot;
			var screenshot = scr.GetScreenshot();
			return screenshot;
		}
	}
}
