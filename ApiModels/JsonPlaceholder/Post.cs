using Core.BaseItems;

namespace ApiModels.JsonPlaceholder
{
	[Serializable]
	public class Post : BaseModel
	{
		public int UserId { get; set; }
		public int Id { get; set; }
		public string Title { get; set; }
		public string Body { get; set; }
	}
}
