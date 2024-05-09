using Moleculab.Core.SQLite.DTOs;

namespace Moleculab.Core.SQLite.Interfaces.BaseInterfaces
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
