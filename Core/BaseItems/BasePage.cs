using Core.Configuration;
using log4net;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using Utilities;

namespace Core.BaseItems
{
	public abstract class BasePage
	{
		protected ILog Logger => LogManager.GetLogger(GetType());

		protected IWebDriver Driver => WebDriver.WebDriver.GetDriver(TestHelper.GetTestFullName());
		protected WebDriverWait Wait;

		protected abstract string ExpectedUrl { get; }

		protected BasePage()
		{
			Logger.Info($"Creating new instance of page {GetType()}");
			Wait = new WebDriverWait(Driver, TestConfiguration.Configuration.CurrentDriverConfig.Timeout);
			PageFactory.InitElements(Driver, this);
			Wait.Until((wd) => Driver.Url.Contains(ExpectedUrl));
		}

		public TPage NavigateToUrl<TPage>(string url) where TPage : BasePage, new()
		{
			Driver.Navigate().GoToUrl(url);
			return new TPage();
		}

		public TPage Back<TPage>() where TPage : BasePage, new()
		{
			Driver.Navigate().Back();
			return new TPage();
		}

		public TPage Refresh<TPage>() where TPage : BasePage, new()
		{
			Driver.Navigate().Refresh();
			return new TPage();
		}

	}
}
