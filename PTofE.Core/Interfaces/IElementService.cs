using PTofE.Core.DTOs;

namespace PTofE.Core.Interfaces
{
	public interface IElementService
	{
		Task<List<ElementDto>> GetAllAsync();
		Task<ElementDto> GetByIdAsync(Guid id);
	}
}
