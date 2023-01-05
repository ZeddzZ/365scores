using Core.BaseItems;
using log4net;

namespace Core.Csv
{
	public abstract class CsvReader
	{
		protected static ILog Logger => LogManager.GetLogger(typeof(CsvReader));

		public static IList<IList<string>> Read(string filepath, char separator = ';', bool isHeaderExists = true, bool isSafe = true)
		{
			var list = new List<IList<string>>();
			if (!File.Exists(filepath))
			{
				if (isSafe)
				{
					Logger.Warn($"File with path {filepath} does not exists! Returning empty collection");
					return list;
				}
				throw new FileNotFoundException($"File with path {filepath} does not exists!");
			}
			using (var reader = new StreamReader(filepath))
			{
				Logger.Info($"Reading all data from {filepath}");
				while(!reader.EndOfStream)
				{
					var line = reader.ReadLine();
					var item = line.Split(separator).ToList();
					list.Add(item);
				}
			}
			if(isHeaderExists)
			{
				list.RemoveAt(0);
			}
			return list;
		}

		public static IList<T> ReadToModel<T>(string filepath, char separator = ';', bool isHeaderExists = true, bool isSafe = true) where T : BaseCsvModel
		{
			var items = Read(filepath, separator, isHeaderExists, isSafe);
			return ConvertToModel<T>(items);
		}

		public static IList<T> ConvertToModel<T>(IList<IList<string>> items) where T : BaseCsvModel
		{
			var list = new List<T>();
			foreach (var item in items)
			{
				list.Add(Activator.CreateInstance(typeof(T), item) as T);
			}
			return list;
		}

	}
}
