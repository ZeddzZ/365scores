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
			options.AddArgument("--lang=en-GB"); 
			return new ChromeDriver(options);
		}
	}
}
