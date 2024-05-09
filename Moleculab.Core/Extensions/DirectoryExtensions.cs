using Serilog;

namespace Moleculab.Core.Extensions
{
	public static class DirectoryExtensions
	{
		public static DirectoryInfo? GetRootDirectory(int fromDirectory)
		{
			var directory = Directory.GetParent(Environment.CurrentDirectory);
			for (var i = 0; i < fromDirectory;  i++)
			{
				directory = Directory.GetParent(directory?.FullName
					?? throw new ArgumentNullException("Directory path can not be null"));
				Log.Information("DirectoryExtensions info: {directory}", directory);
			}
			return directory;
		}

		public static string GetRootDirectory()
		{
			if (Environment.GetEnvironmentVariable("IS_CONSOLE") == null || 
				Environment.GetEnvironmentVariable("IS_CONSOLE")?.ToUpper() == "TRUE")
			{
				return Path.GetFullPath(
					Path.Combine(
						AppContext.BaseDirectory, "..", "..", "..", "..", "..", ".."));
			}
			else
			{
				return Path.GetFullPath(
					Path.Combine(
						AppContext.BaseDirectory, "..", "..", "..", ".."));
			}
		}
	}
}
