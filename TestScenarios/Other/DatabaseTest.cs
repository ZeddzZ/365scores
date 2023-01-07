using Core.BaseItems;
using Core.Database;
using Moq;
using NUnit.Framework;
using System.Text.RegularExpressions;

namespace TestScenarios.Other
{
	[TestFixture]
	public class DatabaseTest : BaseTest
	{
		protected string DbName => "TestDb";
		protected DatabaseClient TestDb;

		[SetUp]
		public void BeforeTest()
		{
			TestDb = new DatabaseClient(Configuration.AvailableDatabases.First(el => el.DbName == DbName));
		}

		[TearDown]
		public void AfterTest()
		{
			TestDb.CloseConnection();
		}

		[Test]
		public void DatabaseMockTest()
		{
			var command = "Select * from @Table";
			var parameters = new [] {
				("@Table", "Users" as object)
			};
			var expectedCount = 3;
			var userMask = "^User(\\d+)$";
			var emailMask = "^user(\\d+)@mail.com$";

			var mock = new Mock<DatabaseClient>();
			mock.Setup(db => db.ExecuteCommand<(int userId, string userName, string email)>(command, parameters))
				.Returns(new List<(int userId, string userName, string email)>
			{
				(1, "User1", "user1@mail.com"),
				(2, "User2", "user2@mail.com"),
				(3, "User3", "user3@mail.com"),
			});

			var tableData = mock.Object.ExecuteCommand<(int userId, string userName, string email)>(command, parameters);

			Assert.AreEqual(expectedCount, tableData.Count());
			Assert.IsTrue(tableData.All(el => Regex.IsMatch(el.userName, userMask)));
			Assert.IsTrue(tableData.All(el => Regex.IsMatch(el.email, emailMask)));
		}
	}
}
