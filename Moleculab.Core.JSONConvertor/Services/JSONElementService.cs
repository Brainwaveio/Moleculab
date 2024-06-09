using Newtonsoft.Json;
using Moleculab.Core.JSONConvertor.Interfaces;
using Moleculab.Core.SQLite.DTOs;

namespace Moleculab.Core.Services;

public class JSONElementService : IJSONElementService
{
	private readonly string filePath;

	public JSONElementService()
	{
		var directoryInfo = Directory.GetParent(Environment.CurrentDirectory);
		directoryInfo = Directory.GetParent(directoryInfo?.FullName
			?? throw new ArgumentNullException("Directory path can not be null"));
		directoryInfo = Directory.GetParent(directoryInfo?.FullName
			?? throw new ArgumentNullException("Directory path can not be null"));

		this.filePath = Path.Combine(
			Directory.GetParent(directoryInfo?.FullName
				?? throw new ArgumentNullException("Directory path can not be null"))?.FullName
				?? throw new ArgumentNullException("Directory path can not be null"),
			"JSON",
			"PubChemElements_all.json");
	}

	public async Task<List<ElementDto>> GetAllAsync()
	{
		using StreamReader reader = File.OpenText(filePath);

		string fileContent = await reader.ReadToEndAsync();
		List<ElementDto> elements = JsonConvert.DeserializeObject<List<ElementDto>>(fileContent);

		return elements ?? new List<ElementDto>();
	}

	public async Task<ElementDto> GetByIdAsync(Guid id)
	{
		List<ElementDto> elements = await GetAllAsync();
		return elements.FirstOrDefault(e => e.Id == id) 
			?? throw new ArgumentNullException("Data can not be null");
	}
}
