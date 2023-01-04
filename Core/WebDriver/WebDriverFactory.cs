using Core.Configuration;
using OpenQA.Selenium;

namespace Core.WebDriver
{
	public abstract class WebDriverFactory
	{
		public abstract IWebDriver CreateDriver();

		public static IWebDriver GetDriver()
		{
			switch (TestConfiguration.Configuration.CurrentDriver)
			{
				case WebDriverTypes.Chrome:
					return new ChromeDriverFactory().CreateDriver();
				case WebDriverTypes.Remote:
					return new RemoteDriverFactory().CreateDriver();
				default:
					throw new ArgumentException($"No such driver ({TestConfiguration.Configuration.CurrentDriver}) either available or supported.");
			}
		}
	}
}
