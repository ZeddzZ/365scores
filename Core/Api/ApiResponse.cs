using RestSharp;
using System.Net;

namespace Core.Api
{
	public class ApiResponse
	{
		public RestResponse Response { get; protected set; }

		public RestRequest Request => Response.Request;
		
		public Uri ResponseUri => Response.ResponseUri;

		public CookieCollection Cookies => Response.Cookies;

		public IReadOnlyCollection<HeaderParameter> Headers => Response.Headers;

		public IReadOnlyCollection<HeaderParameter> ContentHeaders => Response.ContentHeaders;

		public string ContentType => Response.ContentType;

		public long ContentLength => Response.ContentLength ?? default;

		public ICollection<string> ContentEncoding => Response.ContentEncoding;

		public string Content => Response.Content;

		public HttpStatusCode StatusCode => Response.StatusCode;

		public ApiResponse(RestResponse response)
		{
			Response = response;
		}
	}
}
