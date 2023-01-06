using log4net;
using OpenQA.Selenium;
using System.Collections.Concurrent;
using Utilities;

namespace Core.WebDriver
{
	public class WebDriver
	{
		private static ILog Logger => LoggerHelper.GetCurrentLogger();
		private static ConcurrentDictionary<string, IWebDriver> _drivers;

		static WebDriver()
		{
			_drivers = new ConcurrentDictionary<string, IWebDriver>();
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
				_drivers.TryAdd(testName, WebDriverFactory.GetDriver());
			}
		}

		public static void RemoveDriver(string testName)
		{
			if (_drivers.ContainsKey(testName))
			{
				Logger.Info($"Removing Instance of WebDriver for test {testName}");
				_drivers[testName].Quit();
				_drivers.TryRemove(testName, out var driver);
			}
		}
	}
}
