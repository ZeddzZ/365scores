using Core.BaseItems;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System.Web;

namespace PageObjects.Google
{
	public class GoogleResultsPage : GoogleBasePage
	{
		protected string SearchValue { get; set; } = string.Empty;
		protected override string ExpectedUrl => base.ExpectedUrl + $"search?q={SearchValue}";

		[FindsBy(How = How.XPath, Using = "//button[@aria-label = 'Search']")]
		public IWebElement SearchButton { get; set; }

		[FindsBy(How = How.XPath, Using = "//div[@id='search']/div/div[@data-async-context]")]
		public IWebElement SearchResultsBox { get; set; }


		public GoogleResultsPage Search(string text)
		{
			Logger.Info($"Searching for {text}");

			SearchBox.Clear();
			SearchBox.SendKeys(text);

			SearchButton.Click();

			return new GoogleResultsPage();
		}

		public GoogleResultsPage() : this(string.Empty)
		{
			
		}

		public GoogleResultsPage(string searchValue)
		{
			SearchValue = searchValue.Replace(" ", "+");
		}

		public IList<(string url, string title)> GetSearchResultLinksAndTitles(IList<IWebElement> results)
		{
			Logger.Info("Getting list of results' links and titles");

			var linksAndTitles = results.Select(el => (el.GetAttribute("href"), el.FindElement(By.TagName("h3")).Text)).ToList();
			return linksAndTitles;

		}

		public IList<IWebElement> GetSearchResults()
		{
			Logger.Info("Getting list of all available results");

			var results = SearchResultsBox.FindElements(By.XPath(".//div[@class = 'yuRUbf']/a"));
			return results;
		
		}

		public TPage OpenResult<TPage>(IWebElement result) where TPage : BasePage, new()
		{
			result.Click();
			return new TPage();
		}
	}
}
