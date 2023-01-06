
namespace ApiModels.JsonPlaceholder
{
	public static class JsonPlaceholderEndpoints
	{
		public static string PostsEndpoint = "/posts/";
		public static string CommentsEndpoint = "/comments/";
		public static string AlbumsEndpoint = "/albums/";
		public static string PhotosEndpoint = "/photos/";
		public static string TodosEndpoint = "/todos/";
		public static string UsersEndpoint = "/users/";

		public static string WithId(string endpoint, int id)
		{
			if(endpoint.Last() != '/')
			{
				endpoint += '/';
			}
			return $"{endpoint}{id}";
		}
	}
}
