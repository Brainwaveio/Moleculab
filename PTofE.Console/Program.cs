using PTofE.Core.JSONConvertor;

public class Program
{
	private static async Task Main(string[] args)
	{
		Console.WriteLine("Hello, World!");

		var tesst = Environment.CurrentDirectory;

		var test = new JsonConverter();
		await test.ConvertToJsonFileAsync(
			"F:\\Projects\\src\\PeriodicTableOfElements\\PTofE.Console\\Input\\PubChemElements_all.json",
			"F:\\Projects\\src\\PeriodicTableOfElements\\PTofE.Console\\Output\\PubChemElements_all.json");

		Console.ReadLine();
	}
}