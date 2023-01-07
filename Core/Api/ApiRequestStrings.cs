namespace Core.Api
{
	public static class ApiRequestStrings
	{
		public static string AddToRequest => "{0} {1} to request";


		public static string AddToRequestMessage(bool isAdded, string additionName) => string.Format(AddToRequest, isAdded ? "Added" : "Adding", additionName);
	}
}
