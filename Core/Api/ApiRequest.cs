using log4net;
using RestSharp;
using Utilities;

namespace Core.Api
{
	public class ApiRequest
	{
		protected ILog Logger => LoggerHelper.GetCurrentLogger();
		public RestRequest Request { get; private set; }
		public Method Method => Request.Method;

		public ApiRequest (string endpoint, Method method = Method.Get)
		{
			Request = new RestRequest(endpoint, method);
		}

		public ApiRequest ()
		{
			Request = new RestRequest();
		}

		public ApiRequest (Uri endpoint, Method method = Method.Get)
		{
			Request = new RestRequest(endpoint, method);
		}

		public void AddParameter(string name, string? value, bool encode = true)
		{
			Logger.Info(ApiRequestStrings.AddToRequestMessage(false, "Parameter"));
			Request =  Request.AddParameter(new GetOrPostParameter(name, value, encode));
			Logger.Info(ApiRequestStrings.AddToRequestMessage(true, "Parameter"));
		}

		public void AddParameter<T>(string name, T value, bool encode = true) where T : struct
		{
			Logger.Info(ApiRequestStrings.AddToRequestMessage(false, "Parameter"));
			Request = Request.AddParameter(name, value.ToString(), encode);
			Logger.Info(ApiRequestStrings.AddToRequestMessage(true, "Parameter"));
		}

		public void AddBody(object obj, string? contentType = null)
		{
			Logger.Info(ApiRequestStrings.AddToRequestMessage(false, "Body"));
			Request = Request.AddBody(obj, contentType);
			Logger.Info(ApiRequestStrings.AddToRequestMessage(true, "Body"));
		}

		public void AddStringBody(string body, DataFormat dataFormat)
		{
			Logger.Info(ApiRequestStrings.AddToRequestMessage(false, "String Body"));
			Request = Request.AddStringBody(body, dataFormat);
			Logger.Info(ApiRequestStrings.AddToRequestMessage(true, "String Body"));
		}
		
		public void AddStringBody(string body, string contentType)
		{
			Logger.Info(ApiRequestStrings.AddToRequestMessage(false, "String Body"));
			Request = Request.AddStringBody(body, contentType);
			Logger.Info(ApiRequestStrings.AddToRequestMessage(true, "String Body"));
		}

		public void AddJsonBody<T>(T obj, string contentType = "application/json") where T : class
		{
			Logger.Info(ApiRequestStrings.AddToRequestMessage(false, "JSON Body"));
			Request = Request.AddJsonBody(obj, contentType);
			Logger.Info(ApiRequestStrings.AddToRequestMessage(true, "JSON Body"));
		}

		public void AddXmlBody<T>(T obj, string contentType = "application/xml", string xmlNamespace = "") where T : class
		{
			Logger.Info(ApiRequestStrings.AddToRequestMessage(false, "XML Body"));
			Request = Request.AddXmlBody(obj, contentType, xmlNamespace);
			Logger.Info(ApiRequestStrings.AddToRequestMessage(true, "XML Body"));
		}

		public void AddObject<T>(T obj, params string[] includedProperties) where T : class
		{
			Logger.Info(ApiRequestStrings.AddToRequestMessage(false, "Object"));
			Request = Request.AddObject(obj, includedProperties);
			Logger.Info(ApiRequestStrings.AddToRequestMessage(true, "Object"));
		}


	}
}
