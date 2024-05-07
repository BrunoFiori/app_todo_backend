using App_Todo_Backend.Core.Repository;
using App_Todo_Backend.Data;
using App_Todo_Backend.Data.Contract;
using App_Todo_Backend.Data.Models;

namespace App_Todo_Backend.Data.Repository
{
    public class RepositoryTodo : GenericRepository<Todo>, IRepositoryTodo
    {
        private readonly TodoDbContext _context;
        public RepositoryTodo(TodoDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
