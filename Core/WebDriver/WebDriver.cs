using log4net;
using OpenQA.Selenium;

namespace Core.WebDriver
{
	public class WebDriver
	{
		private static ILog Logger => LogManager.GetLogger(typeof(WebDriver));
		private static Dictionary<string, IWebDriver> _drivers;

		static WebDriver()
		{
			_drivers = new Dictionary<string, IWebDriver>();
		}

		public static IWebDriver GetDriver(string testName)
		{
			CreateDriver(testName);
			return _drivers[testName];
		}

		public static void CreateDriver(string testName)
		{
			if (!_drivers.ContainsKey(testName))
			{
				Logger.Info($"Creating new Instance of WebDriver for test {testName}");
				_drivers.Add(testName, WebDriverFactory.GetDriver());
			}
		}

		public static void RemoveDriver(string testName)
		{
			if (_drivers.ContainsKey(testName))
			{
				Logger.Info($"Removing Instance of WebDriver for test {testName}");
				_drivers.Remove(testName);
			}
		}
	}
}
