namespace Core.Csv
{
	public class CustomCsvReader : CsvReader
	{
		public string Filepath { get; set; }

		public CustomCsvReader() : this(string.Empty)
		{
		}

		public CustomCsvReader(string filePath)
		{
			Filepath = filePath;
		}

		public virtual IList<IList<string>> Read(char separator = ';', bool isHeaderExists = true, bool isSafe = true)
		{
			return ReadFromFile(Filepath, separator, isHeaderExists, isSafe);
		}
	}
}
