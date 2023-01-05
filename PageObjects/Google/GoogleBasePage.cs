using Core.BaseItems;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace PageObjects.Google
{
	public abstract class GoogleBasePage : BasePage
	{
		protected override string ExpectedUrl => "https://www.google.com/";

		[FindsBy(How = How.XPath, Using = "//input[@aria-label = 'Search']")]
		public IWebElement SearchBox { get; set; }

		protected GoogleBasePage() : base() { }
	}
}
