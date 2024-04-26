using App_Todo_Backend.Data;
using App_Todo_Backend.Data.Contract;
using App_Todo_Backend.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace App_Todo_Backend.Core.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly TodoDbContext _todoDbContext;

        public GenericRepository(TodoDbContext todoDbContext)
        {
            _todoDbContext = todoDbContext;
        }

        public async Task<T> AddAsync(T entity)
        {
            await _todoDbContext.AddAsync(entity);
            return entity;
        }

        public async Task Commit()
        {
            await _todoDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            await Task.Run(() => _todoDbContext.Remove(entity));
        }

        public async Task<bool> Exists(int id)
        {
            var entity = await GetByIdAsync(id);
            return entity != null;
        }

        public async Task<T> GetByIdAsync(int id)
        {   
            return await _todoDbContext.Set<T>().FindAsync(id);
        }

        public async Task<List<T>> ListAllAsync()
        {
            return await _todoDbContext.Set<T>().ToListAsync();

        }

        public async Task<PagedResult<TResult>> ListAllPagedAsync<TResult>(QueryParameters queryParameters)
        {
            var totalSize = await _todoDbContext.Set<T>().CountAsync();
            var items = await _todoDbContext.Set<T>().Skip(queryParameters.PageSize * queryParameters.PageNumber)
                .Take(queryParameters.PageSize)
                .ToListAsync();            

            return new PagedResult<TResult>
            {
                TotalCount = totalSize,
                PageNumber = queryParameters.PageNumber,
                RecordNumber = queryParameters.PageSize,
                Items = items.Cast<TResult>().ToList()
            };
        }

        public async Task UpdateAsync(T entity)
        {
            await Task.Run(() => _todoDbContext.Update(entity));            
        }
    }
}
