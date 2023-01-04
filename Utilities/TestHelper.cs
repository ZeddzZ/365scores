using NUnit.Framework.Interfaces;
using static NUnit.Framework.TestContext;

namespace Utilities
{
	public static class TestHelper
	{
		public static TestAdapter GetCurrentTest()
		{
			return CurrentContext.Test;
		}

		public static string GetTestName()
		{
			return GetCurrentTest().Name;
		}

		public static string GetTestFullName()
		{
			return GetCurrentTest().FullName;
		}

		public static ResultState GetTestResult()
		{
			return CurrentContext.Result.Outcome;
		}

		public static TestStatus GetTestResultStatus()
		{
			return GetTestResult().Status;
		}
	}
}
