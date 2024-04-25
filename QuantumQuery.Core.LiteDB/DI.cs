using Microsoft.Extensions.DependencyInjection;
using QuantumQuery.Core.DTOs;
using QuantumQuery.Core.LiteDB.Interfaces;
using QuantumQuery.Core.LiteDB.Services;

namespace QuantumQuery.Core.LiteDB
{
	public static class DI
	{
		internal static string LiteDBFile => Environment.GetEnvironmentVariable("DATABASE_FILE") ?? 
			throw new ArgumentNullException("DATABASE_FILE can not be null");
		public static string GetSyncGatewayHost => "localhost:4984";

		public static IServiceCollection AddCoreLiteDB(this IServiceCollection services)
		{
			services.AddTransient<IServices<ElementDto>, ElementService>();

			return services;
		}
	}
}
