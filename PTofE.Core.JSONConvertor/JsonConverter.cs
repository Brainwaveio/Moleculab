using Newtonsoft.Json;
using PTofE.Core.JSONConvertor.Model;
using PTofE.Core.DTOs;
using System.Globalization;

namespace PTofE.Core.JSONConvertor
{
	public class JsonConverter
	{
		public async Task ConvertToJsonFileAsync(string inputFilePath, string outputFilePath)
		{
			var inputJson = await File.ReadAllTextAsync(inputFilePath);
			var tableStructure = JsonConvert.DeserializeObject<TableStructure>(inputJson);

			var elements = new List<ElementsDto>();

			if (tableStructure == null)
			{
				return;
			}

			foreach (var row in tableStructure.Table.Row)
			{
				var cells = row.Cell;
				ElemntState elementState = ParseElementState(cells[11]);

				var element = new ElementsDto
				{
					Id = Guid.NewGuid(),
					Index = int.Parse(cells[0]),
					ShortName = cells[1],
					ElementName = cells[2],
					AtomicMass = float.Parse(cells[3], CultureInfo.InvariantCulture),
					CPKHexColor = cells[4],
					ElectronConfiguration = cells[5],
					Electronegativity = TryParseFloat(cells[6]),
					AtomicRadius = TryParseInt(cells[7]),
					IonizationEnergy = TryParseFloat(cells[8]),
					ElectronAffinity = TryParseFloat(cells[9]),
					OxidationStates = cells[10],
					StandardState = elementState,
					MeltingPoint = TryParseFloat(cells[12]),
					BoilingPoint = TryParseFloat(cells[13]),
					Density = TryParseFloat(cells[14]),
					GroupBlock = cells[15],
					YearDiscovered = cells[16]
				};


				elements.Add(element);
			}

			var outputJson = JsonConvert.SerializeObject(elements, Formatting.Indented);
			await File.WriteAllTextAsync(outputFilePath, outputJson);
		}

		private float? TryParseFloat(string input)
		{
			if (float.TryParse(input, NumberStyles.Any, CultureInfo.InvariantCulture, out var result))
			{
				return result;
			}
			return null;
		}

		private int? TryParseInt(string input)
		{
			if (int.TryParse(input, NumberStyles.Any, CultureInfo.InvariantCulture, out var result))
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