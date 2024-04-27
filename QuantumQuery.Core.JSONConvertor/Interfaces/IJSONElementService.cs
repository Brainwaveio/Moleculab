using QuantumQuery.Core.SQLite.DTOs;

namespace QuantumQuery.Core.JSONConvertor.Interfaces
{
	public interface IJSONElementService
	{
		Task<List<ElementDto>> GetAllAsync();
		Task<ElementDto> GetByIdAsync(Guid id);
	}
}
