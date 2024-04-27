using Microsoft.Extensions.DependencyInjection;

namespace QuantumQuery.Core
{
	public static class DI
	{
		public static IServiceCollection AddCore(this IServiceCollection services)
		{
			return services;
		}
	}
}
