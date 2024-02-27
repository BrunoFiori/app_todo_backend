using Microsoft.EntityFrameworkCore;

namespace App_Todo_Backend.Data
{
    public class TodoDbContext: DbContext
    {   
        public TodoDbContext(DbContextOptions<TodoDbContext> options) : base(options)
        {

        }
        public DbSet<Todo> Todos { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
