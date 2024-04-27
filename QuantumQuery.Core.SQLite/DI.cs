using Microsoft.Extensions.DependencyInjection;
using QuantumQuery.Core.SQLite.DTOs;
using QuantumQuery.Core.SQLite.Interfaces;
using QuantumQuery.Core.SQLite.Services;

namespace QuantumQuery.Core.SQLite
{
	public static class DI
	{
		public static IServiceCollection AddSQLiteCore(this IServiceCollection services)
		{
			services.AddTransient<IService<ElementDto, ElementDto>, ElementService>();

			return services;
		}
	}
}