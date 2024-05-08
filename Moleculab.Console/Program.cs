using Moleculab.Core.JSONConvertor;
using Moleculab.Core.Services;
using Moleculab.Core.SQLite;
using Moleculab.Core.SQLite.DTOs;
using Moleculab.DAL.SQLite;
using Moleculab.Math;
using Newtonsoft.Json;

public class Program
{
	private static async Task Main(string[] args)
	{
		//var mapperConfig = MapperConfig.RegisterMaps();
		//var mapper = mapperConfig.CreateMapper();

		DotNetEnv.Env.Load();
		Console.WriteLine("Hello, World!");

		//DatabaseInitializer.InitializeDatabase();

		//var jsonConverter = new JsonConverter();
		//await jsonConverter.ConvertToJsonFileAsync(
		//	"F:\\Projects\\src\\QuantumQuery\\QuantumQuery.Console\\Input\\PubChemElements_all.json",
		//	"F:\\Projects\\src\\QuantumQuery\\QuantumQuery.Console\\Output\\PubChemElements_all.json");

		//var jsonElementService = new JSONElementService();
		//var elementFromJson = await jsonElementService.GetAllAsync();

		//var elements = new List<string>();

		//foreach (var element in elementFromJson)
		//{
		//	elements.Add($"INSERT INTO Element ([Id], [Index], [ShortName], [ElementName], [AtomicMass], [CPKHexColor], [StandardState], [ElectronConfiguration], [OxidationStates], [Electronegativity], [AtomicRadius], [IonizationEnergy], [ElectronAffinity], [MeltingPoint], [BoilingPoint], [Density], [GroupBlock], [YearDiscovered]) VALUES ('{element.Id}', {element.Index}, '{element.ShortName}', '{element.ElementName}', {element.AtomicMass}, '{element.CpkhexColor}', '{element.StandardState}', '{element.ElectronConfiguration}', '{element.OxidationStates}', {element.Electronegativity}, {element.AtomicRadius}, {element.IonizationEnergy}, {element.ElectronAffinity}, {element.MeltingPoint}, {element.BoilingPoint}, {element.Density}, '{element.GroupBlock}', '{element.YearDiscovered}');");
		//}

		//var outputSql = string.Join("\n", elements);
		//await File.WriteAllTextAsync(@"F:\Projects\src\Moleculab\SQL\Data\ElementData.sql", outputSql);

		var compound = new Compound();

		await compound.Add(Element.H, 2);
		await compound.Add(Element.O, 1);
		await compound.Add(Element.Cl, 1);

		Console.WriteLine(compound.CalculateMolecularWeight());

		Console.ReadLine();
	}
}