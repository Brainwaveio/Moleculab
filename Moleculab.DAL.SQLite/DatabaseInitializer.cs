using Microsoft.EntityFrameworkCore;
using Moleculab.Core.Extensions;
using Moleculab.DAL.SQLite.Context;

namespace Moleculab.DAL.SQLite
{
	public static class DatabaseInitializer
	{
		public static void Initialize()
		{
			var dbContext = ServiceLocator.GetService<MoleculabDbContext>();
			dbContext.Database.EnsureCreated();
			InitializeData(dbContext);
		}

		private static void InitializeData(MoleculabDbContext dbContext)
		{
			var sqlFilePath = Path.Combine(
				DirectoryExtensions.GetRootDirectory()?.FullName
				?? throw new NullReferenceException("path to SQL can not be null"),
				"SQL",
				"Data",
				"InitializeData",
				"Data.sql");

			if (File.Exists(sqlFilePath))
			{
				var sqlCommands = File.ReadAllText(sqlFilePath);

				using var transaction = dbContext.Database.BeginTransaction();

				try
				{
					dbContext.Database.ExecuteSqlRaw(sqlCommands);
					transaction.Commit();
				}
				catch (Exception ex)
				{
					Console.WriteLine("Error executing SQL: " + ex.Message);
					transaction.Rollback();
				}
			}
			else
			{
				Console.WriteLine("SQL file not found: " + sqlFilePath);
			}
		}
	}
}
