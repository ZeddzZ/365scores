using Core.Api;
using Core.BaseItems;
using NUnit.Framework;
using RestSharp;

namespace TestScenarios.API
{
	[TestFixture]
	public abstract class ApiBaseTest : BaseTest
	{
		protected ApiClient MainClient => ApiClientCollection.GetClient(Configuration.CurrentEnvironmentConfig.ApiBaseUrl);
		//These two are just examples to show that we can work with 2 clients simultaneously
		protected ApiClient AdditionalClient => ApiClientCollection.GetClient(Configuration.CurrentEnvironmentConfig.UiBaseUrl);
		protected ApiClient ReserveClient => ApiClientCollection.GetClient("https://www.linkedin.com");
	}
}
