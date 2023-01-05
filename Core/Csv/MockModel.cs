using Core.BaseItems;

namespace Core.Csv
{
	public class MockModel : BaseCsvModel
	{
		public string SearchText { get; set; }

		public string ExpectedUrl { get; set; }

		public int ExpectedResultCount { get; set; }

		public MockModel(IList<string> item) : base(item)
		{

		}

		public MockModel() : base(new List<string> { "", "", "0"})
		{

		}

		public override void Map(IList<string> item)
		{
			SearchText = item[0];
			ExpectedUrl = item[1];
			ExpectedResultCount = int.Parse(item[2]);
		}

		public override bool Equals(object? obj)
		{
			var item = obj as MockModel;

			if (item == null)
			{
				return false;
			}

			return SearchText == item.SearchText 
				&& ExpectedUrl == item.ExpectedUrl 
				&& ExpectedResultCount == item.ExpectedResultCount;
		}
	}
}
