using System.Data.SqlClient;

namespace Utilities
{
	public static class DatabaseHelper
	{
        /// <summary>
     /// Maps a SqlDataReader record to an object.
     /// </summary>
     /// <typeparam name="T"></typeparam>
     /// <param name="dataReader"></param>
     /// <param name="newObject"></param>
        public static void MapDataToObject<T>(this SqlDataReader dataReader, T newObject)
        {
            if (newObject == null)
            {
                throw new ArgumentNullException(nameof(newObject));
            }

            var props = newObject.GetProperties();

            for (int i = 0; i < dataReader.FieldCount; i++)
            {
                var prop = props.FirstOrDefault(el => el.Name == dataReader.GetName(i));
                if (prop != null)
                {
                    prop.SetValue(newObject, dataReader.GetValue(i));
                }
            }
        }
    }
}
