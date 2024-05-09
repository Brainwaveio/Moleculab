using Moleculab.Core.SQLite.DTOs;

namespace Moleculab.Core.SQLite.Interfaces
{
	public interface IElementService
	{
		Task<ElementDto> GetByShortNameAsync(string shortName);
	}
}
