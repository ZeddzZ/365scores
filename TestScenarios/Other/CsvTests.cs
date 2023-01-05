using Core.BaseItems;
using Core.Csv;
using NUnit.Framework;

namespace TestScenarios.Other
{
	[TestFixture]
	public class CsvTests : BaseTest
	{
		[Test]
		[TestCase("TestData/TestFile1.csv", 7, TestName = "CsvSafeTest_ExistingFile")]
		[TestCase("TestData/TestFile2.csv", 0, TestName = "CsvSafeTest_NotExistingFile")]
		public void CsvSafeTest(string filepath, int expectedItemsAmount)
		{
			var csvItems = CsvReader.ReadFromFile(filepath, ',', true, true);
			Assert.AreEqual(expectedItemsAmount, csvItems.Count);
		}

		[Test]
		[TestCase("TestData/TestFile2.csv", typeof(FileNotFoundException), TestName = "CsvNotSafeTest_NotExistingFile")]
		public void CsvNotSafeTest(string filepath, Type expectedException)
		{
			Assert.Throws(expectedException, () => CsvReader.ReadFromFile(filepath, ',', isSafe: false));
		}

		[Test]
		[TestCase("TestData/TestFile1.csv", 7, TestName = "CsvMapTest")]
		public void CsvMapTest(string filepath, int expectedItemsAmount)
		{
			var csvItems = CsvReader.ReadFromFileToModel<TestCsvModel>(filepath, ',', true, true);
			Assert.AreEqual(expectedItemsAmount, csvItems.Count);
			Assert.IsEmpty(csvItems.Where(el => el == null));
		}
	}
}
