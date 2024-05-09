using Microsoft.Extensions.DependencyInjection;
using Moleculab.Core.SQLite.Interfaces;
using Moleculab.Core.SQLite.Services;

namespace Moleculab.Core.SQLite
{
	public static class DI
	{
		public static IServiceCollection AddSQLiteCore(this IServiceCollection services)
		{
			services.AddTransient<IElementService, ElementService>();

			return services;
		}
	}
}