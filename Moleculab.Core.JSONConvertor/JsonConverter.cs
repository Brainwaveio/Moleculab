using Newtonsoft.Json;
using Moleculab.Core.JSONConvertor.Model;
using Moleculab.Core.SQLite.DTOs;
using System.Globalization;

namespace Moleculab.Core.JSONConvertor
{
	public class JsonConverter
	{
		public async Task ConvertToJsonFileAsync(string inputFilePath, string outputFilePath)
		{
			var inputJson = await File.ReadAllTextAsync(inputFilePath);
			var tableStructure = JsonConvert.DeserializeObject<TableStructure>(inputJson);

			var elements = new List<ElementDto>();

			if (tableStructure == null)
			{
				return;
			}

			foreach (var row in tableStructure?.Table?.Row
				?? throw new ArgumentNullException("Argument in JSON can not be null"))
			{
				var cells = row.Cell;
				var elementState = ParseElementState(cells?[11]
					?? throw new ArgumentNullException("Argument in JSON can not be null"));

				elements.Add(new()
				{
					Id = Guid.NewGuid(),
					Index = long.Parse(cells[0]),
					ShortName = cells[1],
					ElementName = cells[2],
					AtomicMass = double.Parse(cells[3], CultureInfo.InvariantCulture),
					CpkhexColor = cells[4],
					ElectronConfiguration = cells[5],
					Electronegativity = TryParseBouble(cells[6]),
					AtomicRadius = TryParseLong(cells[7]),
					IonizationEnergy = TryParseBouble(cells[8]),
					ElectronAffinity = TryParseBouble(cells[9]),
					OxidationStates = cells[10],
					StandardState = elementState,
					MeltingPoint = TryParseBouble(cells[12]),
					BoilingPoint = TryParseBouble(cells[13]),
					Density = TryParseBouble(cells[14]),
					GroupBlock = cells[15],
					YearDiscovered = cells[16]
				});
			}

			var outputJson = JsonConvert.SerializeObject(elements, Formatting.Indented);
			await File.WriteAllTextAsync(outputFilePath, outputJson);
		}

		private double? TryParseBouble(string input)
		{
			if (double.TryParse(input, NumberStyles.Any, CultureInfo.InvariantCulture, out var result))
			{
				return result;
			}
			return null;
		}

		private long? TryParseLong(string input)
		{
			if (long.TryParse(input, NumberStyles.Any, CultureInfo.InvariantCulture, out var result))
			{
				return result;
			}
			return null;
		}

		private ElemntState ParseElementState(string state)
		{
			return state switch
			{
				"Expected to be a Solid" => ElemntState.SolidExpected,
				"Expected to be a Gas" => ElemntState.GasExpected,
				"Gas" => ElemntState.Gas,
				_ => ElemntState.Solid
			};
		}
	}
}