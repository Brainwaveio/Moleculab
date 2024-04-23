using LiteDB;
using QuantumQuery.Core.LiteDB.Interfaces;

namespace QuantumQuery.Core.LiteDB.Services
{
	public class BaseService<T> where T : class
	{
		private readonly string _databasePath;
		private readonly object _lock = new object();

		public BaseService(string databasePath)
		{
			_databasePath = databasePath;
		}

		public async Task<List<T>> GetAll()
		{
			return await Task.Run(() =>
			{
				lock (_lock)
				{
					using var db = new LiteDatabase(_databasePath);
					var collection = db.GetCollection<T>();
					return collection.FindAll().ToList<T>();
				}
			});
		}

		public async Task<T> GetById(Guid id)
		{
			return await Task.Run(() =>
			{
				lock (_lock)
				{
					using var db = new LiteDatabase(_databasePath);
					var collection = db.GetCollection<T>();
					return collection.FindById(id);
				}
			});
		}

		public async Task<bool> Update(T item)
		{
			return await Task.Run(() =>
			{
				lock (_lock)
				{
					using var db = new LiteDatabase(_databasePath);
					var collection = db.GetCollection<T>();
					return collection.Update(item);
				}
			});
		}

		public async Task<BsonValue> Insert(T item)
		{
			return await Task.Run(() =>
			{
				lock (_lock)
				{
					using var db = new LiteDatabase(_databasePath);
					var collection = db.GetCollection<T>();
					return collection.Insert(item);
				}
			});
		}

		public async Task<bool> UpdateOrInsert(T item)
		{
			return await Task.Run(() =>
			{
				lock (_lock)
				{
					using var db = new LiteDatabase(_databasePath);
					var collection = db.GetCollection<T>();
					return collection.Upsert(item);
				}
			});
		}

		public async Task<bool> Delete(Guid id)
		{
			return await Task.Run(() =>
			{
				lock (_lock)
				{
					using var db = new LiteDatabase(_databasePath);
					var collection = db.GetCollection<T>();
					return collection.Delete(id);
				}
			});
		}
	}
}
