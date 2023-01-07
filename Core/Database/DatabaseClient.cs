using log4net;
using System.Data;
using System.Data.SqlClient;
using System.Text.Json;
using Utilities;

namespace Core.Database
{
	public class DatabaseClient
	{
		protected ILog Logger => LoggerHelper.GetCurrentLogger();

		public SqlConnection Client { get; private set; }

		public DatabaseClient(string connectionString)
		{
			Logger.Info($"Connecting to database '{connectionString}'");
			Client = new SqlConnection(connectionString);
		}

		public DatabaseClient(Configuration.Database dbConfig) : this(dbConfig.ConnectionString)
		{
		}

		public DatabaseClient()
		{
		}

		public void OpenConnection()
		{
			Client.Open();
		}

		protected SqlDataReader ExecuteCommand(string command, params (string name, object value)[] parameters)
		{
			var cmd = new SqlCommand();
			cmd.Connection = Client;
			cmd.CommandText = command;
			foreach (var parameter in parameters)
			{
				cmd.Parameters.Add(new SqlParameter(parameter.name, parameter.value));
			}
			if(Client.State == System.Data.ConnectionState.Closed 
				|| Client.State == System.Data.ConnectionState.Broken)
			{
				OpenConnection();
			}
			var reader = cmd.ExecuteReader();
			return reader;
		}

		public virtual IEnumerable<T> ExecuteCommand<T>(string command, params (string name, object value)[] parameters) where T: new()
		{
			var reader = ExecuteCommand(command, parameters);
			var list = new List<T>();
			if(!reader.HasRows)
			{
				return list;
			}
			var dataTable = new DataTable();
			dataTable.Load(reader);
			if(dataTable.Rows.Count > 0)
			{
				var serializedTable = JsonSerializer.Serialize(dataTable);
				list = JsonSerializer.Deserialize<List<T>>(serializedTable);
			}
			return list ?? new List<T>();		
		}
		
			public void CloseConnection()
		{
			Client.Close();
		}
	}
}
