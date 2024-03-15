using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App_Todo_Backend.Data.Configurations
{
    public class TodoConfiguration : IEntityTypeConfiguration<Todo>
    {
        public void Configure(EntityTypeBuilder<Todo> builder)
        {
            builder.HasData(
                new Todo
                {
                    Id = 1,
                    Title = "Estudar C#",
                    Done = false,
                    CreatedAt = new DateTime(2024, 02, 27, 12, 16, 25).ToUniversalTime(),
                    Description = "Estudar C# para melhorar minhas habilidades com a linguagem"
                },
                new Todo
                {
                    Id = 2,
                    Title = "Estudar Ciências Contábeis 🤑",
                    Done = false,
                    CreatedAt = new DateTime(2024, 02, 27, 15, 27, 45).ToUniversalTime(),
                    Description = "Estudar Ciências COntábeis para sustentar o Bruno 💕"
                }
            );
        }
    }
}
