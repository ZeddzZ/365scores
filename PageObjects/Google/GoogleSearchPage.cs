using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using Utilities;

namespace PageObjects.Google
{
	public class GoogleSearchPage : GoogleBasePage
	{
		[FindsBy(How = How.XPath, Using = "//input[@value = 'Google Search']")]
		public IWebElement SearchButton { get; set; }

		public GoogleResultsPage Search(string text)
		{
			Logger.Info($"Searching for {text}");
			
			SearchBox.Clear();
			SearchBox.SendKeys(text);
			//Thread.Sleep(1000);
			//SearchButton.Click();
			Driver.JsClick(SearchButton);
			return new GoogleResultsPage(text);
		}
	}
}