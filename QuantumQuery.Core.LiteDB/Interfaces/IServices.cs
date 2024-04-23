using LiteDB;

namespace QuantumQuery.Core.LiteDB.Interfaces
{
	public interface IServices<T> where T : class
	{
		Task<List<T>> GetAll();
		Task<T> GetById(Guid id);
		Task<bool> Update(T item);
		Task<BsonValue> Insert(T item);
		Task<bool> UpdateOrInsert(T item);
		Task<bool> Delete(Guid id);
	}
}
