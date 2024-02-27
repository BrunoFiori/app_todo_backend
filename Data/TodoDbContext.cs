using Microsoft.EntityFrameworkCore;
using System.Web.Helpers;

namespace App_Todo_Backend.Data
{
    public class TodoDbContext : DbContext
    {
        public TodoDbContext(DbContextOptions<TodoDbContext> options) : base(options)
        {

        }
        public DbSet<Todo> Todos { get; set; }
        public DbSet<User> Users { get; set; }

        override protected void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    Name = "Bruno Canteiro Fiori",
                    Email = "brunocfiori@hotmail.com",
                    HashPassword = Crypto.HashPassword("123456")
                },
                new User
                {
                    Id = 2,
                    Name = "Leticia Semensato",
                    Email = "lesemensato@gmail.com",
                    HashPassword = Crypto.HashPassword("123456")
                }
            );

            modelBuilder.Entity<Todo>().HasData(
                new Todo
                {
                    Id = 1,
                    Title = "Estudar C#",
                    Done = false,
                    AuthorId = 1,
                    CreatedAt =  new DateTime(2024, 02, 27, 12, 16, 25).ToUniversalTime(),
                    Description = "Estudar C# para melhorar minhas habilidades com a linguagem"
                },
                new Todo
                {
                    Id = 2,
                    Title = "Estudar Ciências Contábeis 🤑",
                    Done = false,
                    AuthorId = 2,
                    CreatedAt =  new DateTime(2024, 02, 27, 15, 27, 45).ToUniversalTime(),
                    Description = "Estudar Ciências COntábeis para sustentar o Bruno 💕"
                }
            );

        }
    }
}
