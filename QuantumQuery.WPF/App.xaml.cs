using System.Diagnostics;
using System;
using System.Windows;
using System.IO;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using QuantumQuery.Core.Extensions;

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

			this.Exit += OnApplicationExit;
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

		private void OnApplicationExit(object sender, ExitEventArgs e)
		{
			var scriptPath = Path.Combine(DirectoryExtensions.GetRootDirectory()?.FullName
				?? throw new ArgumentNullException("Directory path can not be null"),
				"PowerShell",
				"StopDatabase.ps1");

			var process = new ProcessStartInfo
			{
				FileName = "powershell",
				Arguments = $"-NoProfile -ExecutionPolicy Bypass -File \"{scriptPath}\"",
				UseShellExecute = false,
				CreateNoWindow = true
			};

			var processStart = Process.Start(process);
			processStart?.WaitForExit();

			if (processStart?.ExitCode != 0)
			{
				Log.Error("Error occurred in PowerShell script execution.");
			}
		}
	}
}
