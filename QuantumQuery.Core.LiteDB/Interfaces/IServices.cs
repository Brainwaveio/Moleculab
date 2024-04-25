using LiteDB;

namespace QuantumQuery.Core.LiteDB.Interfaces
{
	public interface IServices<T> where T : class
	{
		Task<List<T>> GetAllAsync();
		Task<T> GetByIdAsync(Guid id);
		Task<bool> UpdateAsync(T item);
		Task<BsonValue> InsertAsync(T item);
		Task<bool> UpdateOrInsertAsync(T item);
		Task<bool> DeleteAsync(Guid id);
	}
}
