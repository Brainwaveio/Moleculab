using QuantumQuery.Core.JSONConvertor;
using QuantumQuery.Core.LiteDB.Services;
using QuantumQuery.Core.Services;
using QuantumQuery.DAl.LiteDB.Model;

public class Program
{
	private static async Task Main(string[] args)
	{
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

		var directoryInfo = Directory.GetParent(Environment.CurrentDirectory);
		directoryInfo = Directory.GetParent(directoryInfo.FullName);
		directoryInfo = Directory.GetParent(directoryInfo.FullName);

		var databasePath = Path.Combine(
				Directory.GetParent(directoryInfo.FullName).FullName,
				"Database.LiteDB");
		var service = new BaseService<Element>(databasePath);

		// Тестування вставки
		var newElement = new Element
		{
			Id = Guid.NewGuid(),
			ElementName = "Hydrogen",
			AtomicMass = 1.008f,
			CPKHexColor = "wdff",
			GroupBlock = "dfg",
			Index = 0,
			ShortName = "H",
		};
		await service.Insert(newElement);
		Console.WriteLine("Element inserted.");

		// Тестування зчитування
		var fetchedElement = await service.GetById(newElement.Id);
		Console.WriteLine($"Element fetched: {fetchedElement.ElementName}");

		// Тестування оновлення
		fetchedElement.ElementName = "Deuterium";
		bool updateResult = await service.Update(fetchedElement);
		Console.WriteLine($"Element updated: {updateResult}");

		// Перевірка оновлення
		var updatedElement = await service.GetById(newElement.Id);
		Console.WriteLine($"Updated Element: {updatedElement.ElementName}");

		// Тестування видалення
		bool deleteResult = await service.Delete(newElement.Id);
		Console.WriteLine($"Element deleted: {deleteResult}");

		// Перевірка видалення
		var deletedElement = await service.GetById(newElement.Id);
		Console.WriteLine($"Element after deletion: {deletedElement?.ElementName ?? "Not found"}");

		//var test = new JsonConverter();
		//await test.ConvertToJsonFileAsync(
		//	"F:\\Projects\\src\\PeriodicTableOfElements\\PTofE.Console\\Input\\PubChemElements_all.json",
		//	"F:\\Projects\\src\\PeriodicTableOfElements\\PTofE.Console\\Output\\PubChemElements_all.json");

		Console.ReadLine();
	}
}