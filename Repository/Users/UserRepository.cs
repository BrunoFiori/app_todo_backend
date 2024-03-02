using App_Todo_Backend.Data;
using App_Todo_Backend.Repository;
using Microsoft.EntityFrameworkCore;

namespace App_Todo_Backend.Contract.Users
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly TodoDbContext _todoDbContext;
        public UserRepository(TodoDbContext todoDbContext) : base(todoDbContext)
        {
            _todoDbContext = todoDbContext;
        }

        public async Task<User> GetTodos(int id)
        {
            return await _todoDbContext.Users
                .Include(x => x.Todos)
                .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
