namespace QuantumQuery.Core.Extensions
{
	public static class DirectoryExtensions
	{
		public static DirectoryInfo? GetRootDirectory(int fromDirectory = 3)
		{
			var directory = Directory.GetParent(Environment.CurrentDirectory);
			for (var i = 0; i < fromDirectory;  i++)
			{
				directory = Directory.GetParent(directory?.FullName
					?? throw new ArgumentNullException("Directory path can not be null"));
			}
			return directory;
		}
	}
}
