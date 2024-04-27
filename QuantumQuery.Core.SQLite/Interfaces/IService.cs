using QuantumQuery.Core.SQLite.DTOs;

namespace QuantumQuery.Core.SQLite.Interfaces
{
	public interface IService<TRequest, TResponse> 
		where TRequest : class
		where TResponse : class
	{
		Task<TRequest> GetById(Guid id);
		Task<List<TRequest>> GetAll();
		Task<TRequest> UpdateOrInsert(TResponse obj);
		Task<DeleteDto> DeleteById(Guid id);
	}
}
