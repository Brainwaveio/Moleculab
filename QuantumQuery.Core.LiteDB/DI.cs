using Microsoft.Extensions.DependencyInjection;

namespace QuantumQuery.Core.LiteDB
{
	public static class DI
	{
		public static IServiceCollection AddCoreLiteDB(this IServiceCollection services)
		{
			return services;
		}
	}
}
