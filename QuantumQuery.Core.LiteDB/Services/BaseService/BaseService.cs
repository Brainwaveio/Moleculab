using LiteDB;
using QuantumQuery.Core.LiteDB.Interfaces;

namespace QuantumQuery.Core.LiteDB.Services.BaseService
{
	public class BaseService<T> : IServices<T> where T : class
	{
		private readonly string _databasePath;

		public BaseService(string databasePath)
		{
			_databasePath = databasePath;
		}

		private async Task<bool> EnsureConnection()
		{
			return await Task.Run(() =>
			{
				try
				{
					using var db = new LiteDatabase(_databasePath);

					return db.GetCollection<T>().FindOne(_ => true) != null;
				}
				catch (Exception)
				{
					return false;
				}
			});
		}

		public async Task<List<T>> GetAllAsync()
		{
			if (!await EnsureConnection())
				throw new InvalidOperationException("Unable to connect to the database.");

			return await Task.Run(() =>
			{
				using var db = new LiteDatabase(_databasePath);

				return new List<T>(db.GetCollection<T>().FindAll());
			});
		}

		public async Task<T> GetByIdAsync(Guid id)
		{
			if (!await EnsureConnection())
				throw new InvalidOperationException("Unable to connect to the database.");

			return await Task.Run(() =>
			{
				using var db = new LiteDatabase(_databasePath);

				return db.GetCollection<T>().FindById(new BsonValue(id));
			});
		}

		public async Task<bool> UpdateAsync(T item)
		{
			if (!await EnsureConnection())
				throw new InvalidOperationException("Unable to connect to the database.");

			return await Task.Run(() =>
			{
				using var db = new LiteDatabase(_databasePath);

				return db.GetCollection<T>().Update(item);
			});
		}

		public async Task<BsonValue> InsertAsync(T item)
		{
			if (!await EnsureConnection())
				throw new InvalidOperationException("Unable to connect to the database.");

			return await Task.Run(() =>
			{
				using var db = new LiteDatabase(_databasePath);

				return db.GetCollection<T>().Insert(item);
			});
		}

		public async Task<bool> UpdateOrInsertAsync(T item)
		{
			if (!await EnsureConnection())
				throw new InvalidOperationException("Unable to connect to the database.");

			return await Task.Run(() =>
			{
				using var db = new LiteDatabase(_databasePath);

				return db.GetCollection<T>().Upsert(item);
			});
		}

		public async Task<bool> DeleteAsync(Guid id)
		{
			if (!await EnsureConnection())
				throw new InvalidOperationException("Unable to connect to the database.");

			return await Task.Run(() =>
			{
				using var db = new LiteDatabase(_databasePath);

				return db.GetCollection<T>().Delete(new BsonValue(id));
			});
		}
	}
}
