using Serilog;

namespace Moleculab.Core.Extensions
{
	public static class DirectoryExtensions
	{
		/// <summary>
		/// use this method only if you are using in Console application 
		/// in MAUI application it won't be work
		/// </summary>
		/// <param name="fromDirectory"></param>
		/// <returns>DirectoryInfo</returns>
		/// <exception cref="ArgumentNullException"></exception>
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

		/// <summary>
		/// to use this method in MAUI application set in environment variable IS_CONSOLE is False
		/// or if you are wan't to use this method in console application, set in environment variable IS_CONSOLE is true or don't set environment variable
		/// </summary>
		/// <returns></returns>
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
