using Core.BaseItems;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace PageObjects.Scores
{
	public abstract class ScoresBasePage : BasePage
	{
		protected override string ExpectedUrl => "https://www.365scores.com";

		[FindsBy(How = How.ClassName, Using = "main-header-module-desktop-logo")]
		public IWebElement Logo { get; set; }

		protected ScoresBasePage() : base() {
			Wait.Until(wd => Driver.FindElements(By.XPath("//header[contains(@class, 'main-header-module')]")).Count > 0);
		}

		public bool IsLogoExists()
		{
			return Logo.Displayed;
		}

	}
}
