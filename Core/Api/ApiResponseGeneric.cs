using RestSharp;
using System.Text.Json;

namespace Core.Api
{
	public class ApiResponse<T> : ApiResponse
	{
		public T Data { get; private set; }

		public ApiResponse(RestResponse<T> response) : base(response)
		{
			Response = response;
			Data = response.Data;
		}

		public ApiResponse(RestResponse response) : base(response)
		{
			Response = response;
			Data = JsonSerializer.Deserialize<T>(response.Content); 
		}

		public static ApiResponse<T> FromResponse(ApiResponse response)
		{
			return new ApiResponse<T>(response.Response);
		}
	}
}
