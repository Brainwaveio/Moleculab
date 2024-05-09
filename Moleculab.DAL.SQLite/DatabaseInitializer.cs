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
		}

		//TODO update this method
		private static void SeedData(MoleculabDbContext dbContext)
		{
			// Ensure the table is created
			dbContext.Database.ExecuteSqlRaw("CREATE TABLE IF NOT EXISTS Products (Id INTEGER PRIMARY KEY, Name TEXT, Price REAL);");

			// Check if any products are already added
			if (!dbContext.Elements.Any())
			{
				dbContext.SaveChanges();
			}
		}
	}
}
