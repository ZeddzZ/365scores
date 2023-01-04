using OpenQA.Selenium;

namespace Utilities
{
	public static class FileHelper
	{
		public static string CreateScreenshotName(string filePath, ScreenshotImageFormat format = ScreenshotImageFormat.Png)
		{
			var testName = TestHelper.GetTestFullName();
			var screeenshotsCount = GetFilesCount(filePath, testName);
			var screenshotName = $"{testName}_{screeenshotsCount}.{format}";
			return Path.Combine(filePath, screenshotName);
		}

		public static int GetFilesCount(string filePath, string fileName)
		{
			var files = Directory.GetFiles(filePath, $"*{fileName}*");
			return files.Count();
		}

		public static void CreateFolder(string path)
		{
			if(!Directory.Exists(path))
			{
				Directory.CreateDirectory(path);
			}
		}
	}
}
