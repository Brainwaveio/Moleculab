using QuantumQuery.Core.JSONConvertor;
using QuantumQuery.Core.Services;

public class Program
{
	private static async Task Main(string[] args)
	{
		Console.WriteLine("Hello, World!");

		var tesst = Environment.CurrentDirectory;

		var t = new ElementService();

		var te = await t.GetAllAsync();

		foreach (var item in te)
		{
			Console.WriteLine(item.Index);
			Console.WriteLine(item.ShortName);
		}

		Console.WriteLine(te);

		//var test = new JsonConverter();
		//await test.ConvertToJsonFileAsync(
		//	"F:\\Projects\\src\\PeriodicTableOfElements\\PTofE.Console\\Input\\PubChemElements_all.json",
		//	"F:\\Projects\\src\\PeriodicTableOfElements\\PTofE.Console\\Output\\PubChemElements_all.json");

		Console.ReadLine();
	}
}