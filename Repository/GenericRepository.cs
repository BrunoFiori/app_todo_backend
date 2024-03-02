using App_Todo_Backend.Contract;
using App_Todo_Backend.Data;
using Microsoft.EntityFrameworkCore;
using System.CodeDom;

namespace App_Todo_Backend.Repository
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

        public async Task UpdateAsync(T entity)
        {
            await Task.Run(() => _todoDbContext.Update(entity));            
        }
    }
}
