using Moleculab.Core.SQLite.DTOs;

namespace Moleculab.Core.JSONConvertor.Interfaces
{
	public interface IJSONElementService
	{
		Task<List<ElementDto>> GetAllAsync();
		Task<ElementDto> GetByIdAsync(Guid id);
	}
}
