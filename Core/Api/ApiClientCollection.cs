using log4net;
using RestSharp.Authenticators;
using RestSharp.Authenticators.OAuth2;
using System.Collections.Concurrent;
using Utilities;

namespace Core.Api
{
	public class ApiClientCollection
	{
		private static ILog Logger => LoggerHelper.GetCurrentLogger();
		private static ConcurrentDictionary<string, ApiClient> _clients;

		static ApiClientCollection()
		{
			_clients = new ConcurrentDictionary<string, ApiClient>();
		}

		public static ApiClient GetClient(string url)
		{
			CreateClient(url);
			return _clients[url];
		}

		public static void CreateClient(string url)
		{
			if (!_clients.ContainsKey(url))
			{
				_clients.TryAdd(url, new ApiClient(url));
			}
		}

		public static void AddAuthenticator(string url, IAuthenticator auth)
		{
			if (_clients.ContainsKey(url))
			{
				_clients[url].AddAuthenticator(auth);
			}
		}

		public static void AddAuthenticator(string url, string username, string password)
		{
			AddAuthenticator(url, new HttpBasicAuthenticator(username, password));
		}

		public static void AddAuthenticator(string url, string token)
		{
			AddAuthenticator(url, new OAuth2AuthorizationRequestHeaderAuthenticator(token, "Bearer"));
		}

		public static void RemoveClient(string url)
		{
			if (_clients.ContainsKey(url))
			{
				Logger.Info($"Removing API Client instance for url {url}");
				_clients.TryRemove(url, out var client);
			}
		}
	}
}
