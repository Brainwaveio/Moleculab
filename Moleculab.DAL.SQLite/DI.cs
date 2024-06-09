using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Moleculab.DAL.SQLite.Context;

namespace Moleculab.DAL.SQLite;

public static class DI
{
	public static IServiceCollection AddSQLiteDAL(this IServiceCollection services, string connectionString)
	{
		return services.AddDbContext<MoleculabDbContext>(option =>
			option.UseSqlite($"Data Source={connectionString};"));
	}
}
