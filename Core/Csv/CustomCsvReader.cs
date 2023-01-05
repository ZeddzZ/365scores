namespace Core.Csv
{
	public class CustomCsvReader : CsvReader
	{
		private string _filepath;

		public CustomCsvReader() : this(string.Empty)
		{
		}

		public CustomCsvReader(string filePath)
		{
			_filepath = filePath;
		}


		public virtual IList<IList<string>> ReadNonStatic(char separator = ';', bool isHeaderExists = true, bool isSafe = true)
		{
			return Read(_filepath, separator, isHeaderExists, isSafe);
		}
	}
}
