using Newtonsoft.Json;
using PTofE.Core.DTOs;
using PTofE.Core.Interfaces;

namespace PTofE.Core.Services
{
	public class ElementService : IElementService
	{
		private readonly string _filePath;

		public ElementService()
		{
			var directoryInfo = Directory.GetParent(Environment.CurrentDirectory);
			directoryInfo = Directory.GetParent(directoryInfo.FullName);
			directoryInfo = Directory.GetParent(directoryInfo.FullName);

			_filePath = Path.Combine(
				Directory.GetParent(directoryInfo.FullName).FullName,
				"PTofE.Core",
				"JSONs",
				"PubChemElements_all.json");
			//F:\Projects\src\PeriodicTableOfElements\PTofE.Core\JSONs\PubChemElements_all.json

			//_filePath = "F:\\Projects\\src\\PeriodicTableOfElements\\PTofE.Core\\JSONs\\PubChemElements_all.json";
		}

		public async Task<List<ElementDto>> GetAllAsync()
		{
			using (var reader = File.OpenText(_filePath))
			{
				var fileContent = await reader.ReadToEndAsync();
				var elements = JsonConvert.DeserializeObject<List<ElementDto>>(fileContent);
				return elements ?? new List<ElementDto>();
			}
		}

		public async Task<ElementDto> GetByIdAsync(Guid id)
		{
			var elements = await GetAllAsync();
			return elements.FirstOrDefault(e => e.Id == id);
		}
	}
}
