using Microsoft.Data.Sqlite;
using QuantumQuery.Core.Extensions;
using System.Data.Common;
using System.Text.RegularExpressions;

namespace QuantumQuery.DAL.SQLite
{
	//TODO update to entity framework
	public static partial class DatabaseInitializer
    {
		private static readonly string _dbPath = Path.Combine(DirectoryExtensions.GetRootDirectory()?.FullName 
			?? throw new ArgumentNullException("Directory path can not be null"), 
			"Database", 
			"Production", 
			"QuantumQuerySQLite.db");

		[GeneratedRegex("[^\\w\\d\\s\\(\\),]")]
		private static partial Regex MyRegex();

		public static void InitializeDatabase()
        {
			if (!File.Exists(_dbPath))
            {
				CreateNewDatabase();
			}
			else
			{
				using var connection = new SqliteConnection($"Data Source={_dbPath}");
				connection.Open();

				if (!IsDatabaseSchemaCorrect(connection))
				{
					BackupDatabaseData(connection);

					File.Delete(_dbPath);
					CreateNewDatabase();
				}
			}
		}

		private static void CreateNewDatabase()
		{
			using var connection = new SqliteConnection($"Data Source={_dbPath}");
			connection.Open();

			var command = connection.CreateCommand();
			command.CommandText = ReadSqlFile();
			command.ExecuteNonQuery();
		}

		private static string ReadSqlFile()
		{
			var sqlPath = Path.Combine(DirectoryExtensions.GetRootDirectory()?.FullName
				?? throw new ArgumentNullException("Directory path can not be null"),
				"SQL",
				"DatabaseInit",
				"setup.sql");

			return File.ReadAllText(sqlPath);
		}

		private static bool IsDatabaseSchemaCorrect(SqliteConnection connection)
		{
			var command = connection.CreateCommand();
			command.CommandText = "SELECT sql FROM sqlite_master WHERE type='table' AND name='Element';";
			var actualSchema = command.ExecuteScalar()?.ToString();

			return NormalizeSql(actualSchema ??
				throw new ArgumentNullException("Directory path can not be null")) 
				== NormalizeSql(ReadExpectedSchema());
		}

		private static string NormalizeSql(string sql)
		{
			if (string.IsNullOrEmpty(sql))
			{
				return string.Empty;
			}

			return MyRegex().Replace(sql, "")
				.Replace(" ", "")
				.Replace("\r", "")
				.Replace("\n", "")
				.Replace("\t", "")
				.ToLowerInvariant();
		}

		private static string ReadExpectedSchema()
		{
			var schemaPath = Path.Combine(DirectoryExtensions.GetRootDirectory()?.FullName 
				?? throw new ArgumentNullException("Directory path can not be null"), 
				"SQL", 
				"DatabaseInit", 
				"expectedStructure.sql");
			return File.ReadAllText(schemaPath);
		}

		private static void BackupDatabaseData(SqliteConnection connection)
		{
			var backupFilePath = Path.Combine(DirectoryExtensions.GetRootDirectory()?.FullName
				?? throw new ArgumentNullException("Directory path can not be null"),
				"Database",
				"Production",
				"BackupDatabaseData",
				"Backup_QuantumQuerySQLite.sql");

			var directoryPath = Path.GetDirectoryName(backupFilePath);
			if (!Directory.Exists(directoryPath))
			{
				Directory.CreateDirectory(directoryPath
					?? throw new ArgumentNullException("Directory path can not be null"));
			}

			using var command = connection.CreateCommand();
			command.CommandText = "SELECT * FROM Element;";
			using var reader = command.ExecuteReader();

			if (reader.Read())
			{
				using var writer = new StreamWriter(backupFilePath);

				while (reader.Read())
				{
					var values = new List<string>();
					for (int i = 0; i < reader.FieldCount; i++)
					{
						var value = reader.IsDBNull(i) ? "NULL" :
							$"'{reader[i].ToString().Replace("'", "''")}'";
						values.Add(value);
					}

					var insertCommand = $"INSERT INTO Element ({string.Join(", ", reader.GetColumnSchema().Select(col => col.ColumnName))}) VALUES ({string.Join(", ", values)});";
					writer.WriteLine(insertCommand);
				}
			}
		}
	}
}
