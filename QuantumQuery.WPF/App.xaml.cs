using System.Diagnostics;
using System;
using System.Windows;
using System.IO;
//using QuantumQuery.Core.SQLite;
using Microsoft.Extensions.DependencyInjection;
//using Serilog.Core;
//using Serilog;

namespace QuantumQuery.WPF
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
		private IServiceProvider _serviceProvider;

		public App()
		{
			var services = new ServiceCollection();
			ConfigureServices(services);
			_serviceProvider = services.BuildServiceProvider();

			this.Exit += OnApplicationExit;
		}

		protected override void OnStartup(StartupEventArgs e)
		{
			base.OnStartup(e);
			DotNetEnv.Env.Load();
			
			//TODO need to add logger
			//var levelSwitch = new LoggingLevelSwitch();

			//Log.Logger = new LoggerConfiguration()
			//	.WriteTo.Seq("https://seq.example.com")
			//	.CreateLogger();
		}

		private void ConfigureServices(IServiceCollection services)
		{
			Core.SQLite.DI.AddSQLiteCore(services);

			services.AddAutoMapper(typeof(Core.SQLite.MapperConfig));
		}

		private void OnApplicationExit(object sender, ExitEventArgs e)
		{
			var directoryInfo = Directory.GetParent(Environment.CurrentDirectory);

			directoryInfo = Directory.GetParent(directoryInfo?.FullName
				?? throw new ArgumentNullException("Directory path can not be null"));

			directoryInfo = Directory.GetParent(directoryInfo?.FullName
				?? throw new ArgumentNullException("Directory path can not be null"));

			var scriptPath = Path.Combine(
				Directory.GetParent(
					directoryInfo?.FullName 
					?? throw new ArgumentNullException("Directory path can not be null"))?.FullName
					?? throw new ArgumentNullException("Directory path can not be null"),
				"PowerShell",
				"StopDatabase.ps1");

			var psi = new ProcessStartInfo
			{
				FileName = "powershell",
				Arguments = $"-NoProfile -ExecutionPolicy Bypass -File \"{scriptPath}\"",
				UseShellExecute = false,
				CreateNoWindow = true
			};

			var psProcess = Process.Start(psi);
			psProcess?.WaitForExit();

			if (psProcess?.ExitCode != 0)
			{
				Console.WriteLine("Error occurred in PowerShell script execution.");
			}
		}
	}
}
