using Core.BaseItems;

namespace Core.Csv
{
	public class TestCsvModel : BaseCsvModel
	{
		public string Plant { get; set; }

		public string MaterialId { get; set; }

		public double Density { get; set; }

		public int StorageAmount { get; set; }

		public TestCsvModel(IList<string> item) : base(item)
		{
		}

		public override void Map(IList<string> item)
		{
			Plant = item[0];
			MaterialId = item[1];
			Density = double.Parse(item[2].Replace('.', ','));
			StorageAmount = int.Parse(item[3]);
		}
	}
}
