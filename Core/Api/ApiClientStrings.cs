using RestSharp;

namespace Core.Api
{
	public static class ApiClientStrings
	{
		public static string ExecuteRequest => "Executing request of type '{0}' to endpoint '{1}'";
		public static string CreateRequest => "{0} new API Client for Url '{1}'";
		public static string AddAuth => "{0} authenticator of type '{1}' to client";


		public static string ExecuteRequestMessage(Method method, string endpoint) => string.Format(ExecuteRequest, method.ToString(), endpoint);
		public static string CreateClientMessage(bool isCreated, string url) => string.Format(CreateRequest, isCreated ? "Created" : "Creating", url);
		public static string AddAuthMessage(bool isAdded, Type authType) => string.Format(AddAuth, isAdded ? "Added" : "Adding", authType.Name);
	}
}
