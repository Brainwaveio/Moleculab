using Microsoft.Extensions.DependencyInjection;
using Serilog;
using System.Windows;

namespace QuantumQuery.WPF
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
		public App()
		{
			var services = new ServiceCollection();

			ConfigureServices(services);

			services.BuildServiceProvider();
		}

		protected override void OnStartup(StartupEventArgs e)
		{
			base.OnStartup(e);
			DotNetEnv.Env.Load();

			Log.Logger = new LoggerConfiguration()
				.MinimumLevel.Debug()
				.WriteTo.Console()
				.WriteTo.Seq("http://localhost:5341")
				.CreateLogger();

			Log.Information("Application Starting Up");
		}

		private void ConfigureServices(IServiceCollection services)
		{
			Core.SQLite.DI.AddSQLiteCore(services);

			services.AddAutoMapper(typeof(Core.SQLite.MapperConfig));
		}
	}
}
