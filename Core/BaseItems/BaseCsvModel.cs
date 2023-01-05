
namespace Core.BaseItems
{
	public abstract class BaseCsvModel
	{
		protected BaseCsvModel(IList<string> item)
		{
			//parse this item in constructor
			Map(item);
		}

		public abstract void Map(IList<string> item);
	}
}
