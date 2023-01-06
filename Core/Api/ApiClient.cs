using log4net;
using RestSharp;
using RestSharp.Authenticators;
using RestSharp.Authenticators.OAuth2;
using Utilities;

namespace Core.Api
{
	public class ApiClient
	{
		protected ILog Logger => LoggerHelper.GetCurrentLogger();
		public RestClient Client { get; private set; }

		public ApiClient(string url)
		{
			Logger.Info(ApiClientStrings.CreateClientMessage(false, url));
			Client = new RestClient(url);
			Logger.Info(ApiClientStrings.CreateClientMessage(true, url));
		}

		public ApiClient(Uri url)
		{
			Logger.Info(ApiClientStrings.CreateClientMessage(false, url.ToString()));
			Client = new RestClient(url);
			Logger.Info(ApiClientStrings.CreateClientMessage(true, url.ToString()));
		}

		public void AddAuthenticator(IAuthenticator auth)
		{

			Logger.Info(ApiClientStrings.AddAuthMessage(false, auth.GetType()));
			Client.Authenticator = auth;
			Logger.Info(ApiClientStrings.AddAuthMessage(false, auth.GetType()));
		}

		public void AddAuthenticator(string username, string password)
		{
			AddAuthenticator(new HttpBasicAuthenticator(username, password));
		}

		public void AddAuthenticator(string token)
		{
			AddAuthenticator(new OAuth2AuthorizationRequestHeaderAuthenticator(token, "Bearer"));
		}

		public ApiResponse Execute(ApiRequest request, Method httpMethod)
		{
			Logger.Info(ApiClientStrings.ExecuteRequestMessage(httpMethod, request.Request.Resource));
			return new ApiResponse(Client.Execute(request.Request, httpMethod));
		}

		public ApiResponse<T> Execute<T>(ApiRequest request, Method httpMethod)
		{
			Logger.Info(ApiClientStrings.ExecuteRequestMessage(httpMethod, request.Request.Resource));
			return new ApiResponse<T>(Client.Execute<T>(request.Request, httpMethod));
		}

		public ApiResponse Execute(ApiRequest request)
		{
			return Execute(request, request.Method);
		}

		public ApiResponse<T> Execute<T>(ApiRequest request)
		{
			return Execute<T>(request, request.Method);
		}

		public T? Get<T>(ApiRequest request)
		{
			Logger.Info(ApiClientStrings.ExecuteRequestMessage(Method.Get, request.Request.Resource));
			return Client.Get<T>(request.Request);
		}

		public ApiResponse Get(ApiRequest request)
		{
			Logger.Info(ApiClientStrings.ExecuteRequestMessage(Method.Get, request.Request.Resource));
			return new ApiResponse(Client.Get(request.Request));
		}

		public T? Post<T>(ApiRequest request)
		{
			Logger.Info(ApiClientStrings.ExecuteRequestMessage(Method.Post, request.Request.Resource));
			return Client.Get<T>(request.Request);
		}
		public ApiResponse Post(ApiRequest request)
		{
			Logger.Info(ApiClientStrings.ExecuteRequestMessage(Method.Post, request.Request.Resource));
			return new ApiResponse(Client.Post(request.Request));
		}

		public T? Put<T>(ApiRequest request)
		{
			Logger.Info(ApiClientStrings.ExecuteRequestMessage(Method.Put, request.Request.Resource));
			return Client.Get<T>(request.Request);
		}

		public ApiResponse Put(ApiRequest request)
		{
			Logger.Info(ApiClientStrings.ExecuteRequestMessage(Method.Put, request.Request.Resource));
			return new ApiResponse(Client.Put(request.Request));
		}

		public T? Patch<T>(ApiRequest request)
		{
			Logger.Info(ApiClientStrings.ExecuteRequestMessage(Method.Patch, request.Request.Resource));
			return Client.Get<T>(request.Request);
		}

		public ApiResponse Patch(ApiRequest request)
		{
			Logger.Info(ApiClientStrings.ExecuteRequestMessage(Method.Patch, request.Request.Resource));
			return new ApiResponse(Client.Patch(request.Request));
		}

		public T? Delete<T>(ApiRequest request)
		{
			Logger.Info(ApiClientStrings.ExecuteRequestMessage(Method.Delete, request.Request.Resource));
			return Client.Delete<T>(request.Request);
		}

		public ApiResponse Delete(ApiRequest request)
		{
			Logger.Info(ApiClientStrings.ExecuteRequestMessage(Method.Delete, request.Request.Resource));
			return new ApiResponse(Client.Delete(request.Request));
		}
	}
}
