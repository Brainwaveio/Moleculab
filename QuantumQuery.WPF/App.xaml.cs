using System.Diagnostics;
using System;
using System.Windows;
using System.IO;

namespace QuantumQuery.WPF
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
		public App()
		{
			this.Exit += OnApplicationExit;
		}

		protected override void OnStartup(StartupEventArgs e)
		{
			base.OnStartup(e);
			DotNetEnv.Env.Load();
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
