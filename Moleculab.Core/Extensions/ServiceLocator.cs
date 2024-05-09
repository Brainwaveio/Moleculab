using Microsoft.Extensions.DependencyInjection;

namespace Moleculab.Core.Extensions
{
	public class ServiceLocator
	{
		private static IServiceProvider _serviceProvider;

		public static void SetServiceProvider(IServiceProvider serviceProvider)
		{
			_serviceProvider = serviceProvider;
		}

		public static T GetService<T>()
		{
			return _serviceProvider.GetRequiredService<T>();
		}
	}
}
