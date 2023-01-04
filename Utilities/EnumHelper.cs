namespace Utilities
{
	public static class EnumHelper
	{
		public static T GetEnumValue<T>(string? value) where T : struct, Enum 
		{
			if(Enum.TryParse<T>(value, out var result))
			{
				return result;
			}
			return default(T);
		}
	}
}
