using Newtonsoft.Json;
using QuantumQuery.Core.JSONConvertor.Interfaces;
using QuantumQuery.Core.SQLite.DTOs;

namespace QuantumQuery.Core.Services
{
	public class JSONElementService : IJSONElementService
	{
		private readonly string _filePath;

		public JSONElementService()
		{
			var directoryInfo = Directory.GetParent(Environment.CurrentDirectory);
			directoryInfo = Directory.GetParent(directoryInfo?.FullName
				?? throw new ArgumentNullException("Directory path can not be null"));
			directoryInfo = Directory.GetParent(directoryInfo?.FullName
				?? throw new ArgumentNullException("Directory path can not be null"));

			_filePath = Path.Combine(
				Directory.GetParent(directoryInfo?.FullName
					?? throw new ArgumentNullException("Directory path can not be null"))?.FullName
					?? throw new ArgumentNullException("Directory path can not be null"),
				"QuantumQuery.Core",
				"JSONs",
				"PubChemElements_all.json");
		}

		public async Task<List<ElementDto>> GetAllAsync()
		{
			using var reader = File.OpenText(_filePath);

			var fileContent = await reader.ReadToEndAsync();
			var elements = JsonConvert.DeserializeObject<List<ElementDto>>(fileContent);

			return elements ?? new List<ElementDto>();
		}

		public async Task<ElementDto> GetByIdAsync(Guid id)
		{
			var elements = await GetAllAsync();
			return elements.FirstOrDefault(e => e.Id == id) 
				?? throw new ArgumentNullException("Data can not be null");
		}
	}
}
