using Moleculab.Core.JSONConvertor;
using Moleculab.Core.SQLite;
using Moleculab.DAL.SQLite;

public class Program
{
	private static async Task Main(string[] args)
	{
		//var mapperConfig = MapperConfig.RegisterMaps();
		//var mapper = mapperConfig.CreateMapper();

		DotNetEnv.Env.Load();
		Console.WriteLine("Hello, World!");

		//DatabaseInitializer.InitializeDatabase();

		var test = new JsonConverter();
		await test.ConvertToJsonFileAsync(
			"F:\\Projects\\src\\QuantumQuery\\QuantumQuery.Console\\Input\\PubChemElements_all.json",
			"F:\\Projects\\src\\QuantumQuery\\QuantumQuery.Console\\Output\\PubChemElements_all.json");

		Console.ReadLine();
	}
}