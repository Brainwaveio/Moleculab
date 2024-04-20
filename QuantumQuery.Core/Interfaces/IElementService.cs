using QuantumQuery.Core.DTOs;

namespace QuantumQuery.Core.Interfaces
{
	public interface IElementService
	{
		Task<List<ElementDto>> GetAllAsync();
		Task<ElementDto> GetByIdAsync(Guid id);
	}
}
