using Moleculab.Core.SQLite.DTOs;
using Moleculab.Core.SQLite.Interfaces.BaseInterfaces;

namespace Moleculab.Core.SQLite.Interfaces
{
	public interface IElementService : IService<ElementDto, ElementDto>
	{
		Task<ElementDto> GetByShortNameAsync(Element shortName);
		Task<ElementDto> GetByAtomicMassAsync(int tomicMass);
	}
}
