using log4net;
using System.Collections;
using System.Reflection;
using System.Text;
using Utilities;

namespace Core.BaseItems
{
	[Serializable]
	public abstract class BaseModel
	{
		protected ILog Logger => LogManager.GetLogger(GetType());

		public override string ToString()
		{
			var sb = new StringBuilder();
			var prefix = "\t";

			sb.AppendLine(GetType().Name);
			sb.AppendLine("{");

			var fields = this.GetFields();
			AppendItems(fields, (type, instance) => ((FieldInfo)type).GetValue(instance), sb, prefix);

			var properties = this.GetProperties();
			AppendItems(properties, (type, instance) => ((PropertyInfo)type).GetValue(instance), sb, prefix);

			sb.AppendLine("}");
			return sb.ToString();
		}

		private void AppendItems(IEnumerable<MemberInfo> members, Func<object, object?, object?> getValue, StringBuilder sb, string prefix = "\t")
		{
			foreach (var member in members)
			{
				if (member.IsEnumerable())
				{
					sb.AppendLine($"{prefix}{member.Name}:");
					sb.AppendLine($"{prefix}{{");
					var collection = getValue(member, this) as IEnumerable;
					if (collection != null)
					{
						foreach (var item in collection)
						{
							sb.AppendLine($"{prefix}{prefix}'{item}'");
						}
					}
					sb.AppendLine($"{prefix}}}");
				}
				sb.AppendLine($"{prefix}{member.Name}: '{getValue(member, this)}'");
			}
		}
	}
}
