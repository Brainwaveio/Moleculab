using Microsoft.Extensions.DependencyInjection;
using QuantumQuery.Core.Interfaces;
using QuantumQuery.Core.Services;

namespace QuantumQuery.Core
{
	public static class DI
	{
		public static IServiceCollection AddCore(this IServiceCollection services)
		{
			services.AddTransient<IElementService, ElementService>();
				
			return services;
		}
	}
}
