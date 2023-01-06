using log4net;
using System.Collections;
using System.Reflection;

namespace Utilities
{
	public static class ReflectionHelper
	{
		private static ILog Logger => LoggerHelper.GetCurrentLogger();
		private static BindingFlags _defaultFlags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance;

		public static IEnumerable<PropertyInfo> GetProperties(this object obj)
		{
			return obj.GetProperties(_defaultFlags);
		}

		public static IEnumerable<PropertyInfo> GetProperties(this object obj, BindingFlags flags)
		{
			Logger.Info($"Getting all properties from {obj.GetType()}");
			return obj.GetType().GetProperties(flags).AsEnumerable();
		}

		public static IEnumerable<FieldInfo> GetFields(this object obj)
		{
			return obj.GetFields(_defaultFlags);
		}

		public static IEnumerable<FieldInfo> GetFields(this object obj, BindingFlags flags)
		{
			Logger.Info($"Getting all fields from {obj.GetType()}");
			return obj.GetType().GetFields(flags).AsEnumerable();
		}

		public static bool IsEnumerable(this object obj)
		{
			Logger.Info($"Checking if {obj.GetType()} is IEnumerable and not a String (String is IEnumerable<char>)");
			return obj.GetType().Name != nameof(String)
				&& obj.GetType().GetInterface(nameof(IEnumerable)) != null;
		}

		public static bool IsCollection(this object obj)
		{
			Logger.Info($"Checking if {obj.GetType()} is ICollection");
			return obj.GetType().GetInterface(nameof(ICollection)) != null;
		}
	}
}