using ApiModels.JsonPlaceholder;
using Core.Api;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using System.Net;

namespace TestScenarios.API
{
	[TestFixture]
	public class JSonPlaceholderTests : ApiBaseTest
	{
		protected int UserId { get; set; }
		protected int MinPostId => 1;
		protected int MaxPostId => 100;

		[OneTimeSetUp]
		public void BeforeAll()
		{
			UserId = new Random().Next(1, 11);
		}

		[Test]
		public void JsonPlaceholderEmailTest()
		{
			var getUserRequest = new ApiRequest(JsonPlaceholderEndpoints.WithId(JsonPlaceholderEndpoints.UsersEndpoint, UserId));
			var user = MainClient.Get<User>(getUserRequest);
			Logger.Info($"EMail for user with ID {UserId} is {user.Email}");
			Assert.IsNotNull(user.Email);
		}

		[Test]
		public void JsonPlaceholderPostsTest()
		{
			var getPostsRequest = new ApiRequest(
				JsonPlaceholderEndpoints.WithId(JsonPlaceholderEndpoints.UsersEndpoint, UserId) +
				JsonPlaceholderEndpoints.PostsEndpoint);
			var posts = MainClient.Get<IList<Post>>(getPostsRequest);
			Assert.IsNotEmpty(posts);
			foreach (var post in posts)
			{
				Assert.AreEqual(post.UserId, UserId);
				Assert.GreaterOrEqual(post.Id, MinPostId);
				Assert.LessOrEqual(post.Id, MaxPostId);
			}
		}

		[Test]
		public void JsonPlaceholderPostUserTest()
		{
			var post = new Post
			{
				UserId = UserId,
				Title = "My Test Title",
				Body = "My Test Body",
			};
			var postNewPostRequest = new ApiRequest(
				JsonPlaceholderEndpoints.WithId(JsonPlaceholderEndpoints.UsersEndpoint, UserId) +
				JsonPlaceholderEndpoints.PostsEndpoint);
			postNewPostRequest.AddBody(post);
			var response = MainClient.Post(postNewPostRequest);
			Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);
			//Just because in this  particular case Post returns object with user Id as string (everywhere else it is int)
			//Here is such workaround
			//var createdPost = JsonSerializer.Deserialize<Post>(response.Content);
			var createdPost = JObject.Parse(response.Content);
			Assert.AreEqual(post.UserId, int.Parse(createdPost["userId"].ToString()));
			Assert.AreEqual(post.Title, createdPost["title"].ToString());
			Assert.AreEqual(post.Body, createdPost["body"].ToString());
		}
	}
}
