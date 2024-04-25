using QuantumQuery.Core.DTOs;
using QuantumQuery.Core.LiteDB.Services.BaseService;

namespace QuantumQuery.Core.LiteDB.Services
{
	public class ElementService : BaseService<ElementDto>
	{
		public ElementService(string databasePath) : base(databasePath)
		{
		}
	}
}
