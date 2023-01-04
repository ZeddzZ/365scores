using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;

namespace Core.WebDriver
{
	public class RemoteDriverFactory : WebDriverFactory
	{
		public override IWebDriver CreateDriver()
		{
			return new RemoteWebDriver(new ChromeOptions());
		}
	}
}
