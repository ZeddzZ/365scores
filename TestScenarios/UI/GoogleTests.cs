using NUnit.Framework;
using PageObjects.Google;
using PageObjects.Scores;
using UiTests;

namespace TestScenarios.UI
{
	[TestFixture]
	public class GoogleTests : UiBaseTest
	{
		GoogleSearchPage searchPage;

		[SetUp]
		public void BeforeTest()
		{
			Driver.Navigate().GoToUrl(Configuration.CurrentEnvironmentConfig.UiBaseUrl);
			searchPage = new GoogleSearchPage();
		}

		[Test]
		[TestCase("Livescore in Israel", "https://www.365scores.com", 0, TestName = "GoogleLifescoreTest")]
		[TestCase("Livescore in Israel 365 scores", "https://www.365scores.com", 2, TestName = "GoogleLifescoreTest_365")]
		public void GoogleLifescoreTest(string searchText, string expectedUrl, int expectedResultsCount)
		{			
			var resultsPage = searchPage.Search(searchText);
			var results = resultsPage.GetSearchResults();
			var linksAndTitles = resultsPage.GetSearchResultLinksAndTitles(results);
			var expectedWebsites = linksAndTitles.Where(el => el.url.Contains(expectedUrl));
			Assert.AreEqual(expectedResultsCount, expectedWebsites.Count());
			foreach(var website in expectedWebsites)
			{
				var resultItem = results.First(el => el.GetAttribute("href") == website.url);
				var scoresPage = resultsPage.OpenResult<ScoresMainPage>(resultItem);
				Assert.IsTrue(scoresPage.IsLogoExists());
				resultsPage = scoresPage.Back<GoogleResultsPage>();
				results = resultsPage.GetSearchResults();
			}
		}
	}
}
