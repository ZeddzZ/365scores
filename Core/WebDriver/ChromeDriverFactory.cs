using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Core.WebDriver
{
	public class ChromeDriverFactory : WebDriverFactory
	{
		public override IWebDriver CreateDriver()
		{
			var options = new ChromeOptions();
			options.AddArgument("start-maximized");
			return new ChromeDriver(options);
		}
	}
}
