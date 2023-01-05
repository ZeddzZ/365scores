using Core.Csv;
using Moq;
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
		[TestCase("Livescore in Israel", "https://www.365scores.com", 0, TestName = "GoogleSearchTest")]
		[TestCase("Livescore in Israel 365 scores", "https://www.365scores.com", 2, TestName = "GoogleSearchTest_365")]
		public void GoogleSearchTest(string searchText, string expectedUrl, int expectedResultsCount)
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

		[Test, Retry(5)]
		[TestCaseSource(nameof(MockCase))]
		public void GoogleSearchMockTest(string searchText, string expectedUrl, int expectedResultsCount)
		{
			var resultsPage = searchPage.Search(searchText);
			var results = resultsPage.GetSearchResults();
			var linksAndTitles = resultsPage.GetSearchResultLinksAndTitles(results);
			var expectedWebsites = linksAndTitles.Where(el => el.url.Contains(expectedUrl));
			Assert.AreEqual(expectedResultsCount, expectedWebsites.Count());
		}

		private static IEnumerable<TestCaseData> MockCase()
		{
			int index = 0;
			var mock = new Mock<CustomCsvReader>();
			mock.Setup(csv => csv.Read(',', true, true)).Returns(new List<IList<string>>
			{
				new List<string>
				{
					"Team Liquid",
					"https://liquipedia.net/",
					"1",
				}
			});
			var models = CsvReader.ConvertToModel<MockModel>(mock.Object.Read(',', true, true));
			foreach( var model in models)
			{
				var data = new TestCaseData(model.SearchText, model.ExpectedUrl, model.ExpectedResultCount);
				if (index++ > 0)
				{
					data.SetName($"GoogleSearchMockTest_{index++}");
				}
				else
				{
					data.SetName($"GoogleSearchMockTest");
				}
				yield return data;
			}
		}
	}
}
