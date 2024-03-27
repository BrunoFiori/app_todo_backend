using App_Todo_Backend.Models.QueryParameters;

namespace App_Todo_Backend.Contract
{
    public interface IGenericRepository<T> where T : class
    {
        Task<List<T>> ListAllAsync();
        Task<PagedResult<TResult>> ListAllPagedAsync<TResult>(QueryParameters queryParameters);
        Task<T> GetByIdAsync(int id);
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task<bool> Exists(int id);
        Task Commit();
    }    
}
