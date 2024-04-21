using Microsoft.Extensions.DependencyInjection;
using QuantumQuery.WPF.MVVM.View;
using QuantumQuery.WPF.MVVM.ViewModel;
using System;
using System.Windows;

namespace QuantumQuery.WPF
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
		private readonly IServiceProvider _serviceProvider;

		public App()
		{
			var serviceCollection = new ServiceCollection();
			ConfigureServices(serviceCollection);
			_serviceProvider = serviceCollection.BuildServiceProvider();
		}

		private void ConfigureServices(IServiceCollection services)
		{
			QuantumQuery.Core.DI.AddCore(services);

			services.AddSingleton<MainWindowModel>();
			services.AddTransient<LeftSideBarModel>();

			services.AddTransient<LeftSideBar>(provider =>
				new LeftSideBar(provider.GetRequiredService<LeftSideBarModel>()));

			services.AddSingleton<MainWindow>(provider =>
				new MainWindow(provider.GetRequiredService<MainWindowModel>()));
		}

		protected override async void OnStartup(StartupEventArgs e)
		{
			base.OnStartup(e);

			var mainWindow = _serviceProvider.GetService<MainWindow>();
			mainWindow?.Show();

			var viewModel = _serviceProvider.GetService<MainWindowModel>();
			if (viewModel != null)
			{
				await viewModel.LeftSideBarVM.InitializeAsync().ConfigureAwait(false);
			}
		}
	}
}
