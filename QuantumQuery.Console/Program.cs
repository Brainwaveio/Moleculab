using QuantumQuery.Core.JSONConvertor;
using QuantumQuery.Core.SQLite;
using QuantumQuery.DAL.SQLite;

public class Program
{
	private static async Task Main(string[] args)
	{
		var mapperConfig = MapperConfig.RegisterMaps();
		var mapper = mapperConfig.CreateMapper();

		DotNetEnv.Env.Load();
		Console.WriteLine("Hello, World!");

		//DatabaseInitializer.InitializeDatabase();

		//var test = new JsonConverter();
		//await test.ConvertToJsonFileAsync(
		//	"F:\\Projects\\src\\PeriodicTableOfElements\\PTofE.Console\\Input\\PubChemElements_all.json",
		//	"F:\\Projects\\src\\PeriodicTableOfElements\\PTofE.Console\\Output\\PubChemElements_all.json");

		Console.ReadLine();
	}
}