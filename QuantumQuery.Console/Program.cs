using QuantumQuery.Core.JSONConvertor;
using QuantumQuery.Core.LiteDB.Services;
using QuantumQuery.Core.Services;
using QuantumQuery.DAl.LiteDB.Model;

public class Program
{
	private static async Task Main(string[] args)
	{
		DotNetEnv.Env.Load();
		Console.WriteLine("Hello, World!");

		////var tesst = Environment.CurrentDirectory;

		//var t = new ElementService();

		//var te = await t.GetAllAsync();

		//foreach (var item in te)
		//{
		//	Console.WriteLine(item.Index);
		//	Console.WriteLine(item.ShortName);
		//}

		//Console.WriteLine(te);

		//string databasePath = "myTestDb.db";
		//var elementService = new QuantumQuery.Core.LiteDB.Services.TestElementService(databasePath);

		//// Створення нового елемента
		//var newElement = new Element
		//{
		//	Id = Guid.NewGuid(),
		//	ElementName = "Neon",
		//	AtomicMass = 20.180f,
		//	CPKHexColor = "dfsgf",
		//	GroupBlock = "ds",
		//	Index = 1,
		//	ShortName = "H",
		//};

		//// Вставка елемента
		//await elementService.Insert(newElement);
		//Console.WriteLine($"Element inserted: {newElement.ElementName}");

		//// Оновлення елемента
		//newElement.ElementName = "Modified Neon";
		//await elementService.Update(newElement);
		//Console.WriteLine($"Element updated: {newElement.ElementName}");

		//// Отримання елемента
		//var element = await elementService.GetById(newElement.Id);
		//Console.WriteLine($"Retrieved Element: {element.ElementName}");

		//// Видалення елемента
		//await elementService.Delete("");
		//Console.WriteLine("Element deleted");

		//// Отримання всіх елементів
		//var allElements = await elementService.GetAll();
		//Console.WriteLine("All elements:");
		//foreach (var elem in allElements)
		//{
		//	Console.WriteLine($"Element: {elem.ElementName}");
		//}

		//var test = new JsonConverter();
		//await test.ConvertToJsonFileAsync(
		//	"F:\\Projects\\src\\PeriodicTableOfElements\\PTofE.Console\\Input\\PubChemElements_all.json",
		//	"F:\\Projects\\src\\PeriodicTableOfElements\\PTofE.Console\\Output\\PubChemElements_all.json");

		Console.ReadLine();
	}
}