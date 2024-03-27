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
                    Title = "Example 1",
                    Done = false,
                    CreatedAt = new DateTime(2024, 02, 27, 12, 16, 25).ToUniversalTime(),
                    Description = "Example Description 1"
                },
                new Todo
                {
                    Id = 2,
                    Title = "Exmple 2",
                    Done = false,
                    CreatedAt = new DateTime(2024, 02, 27, 12, 16, 25).ToUniversalTime(),
                    Description = "Example Description 2"
                },
                new Todo
                {
                    Id = 3,
                    Title = "Example 3",
                    Done = false,
                    CreatedAt = new DateTime(2024, 02, 27, 12, 16, 25).ToUniversalTime(),
                    Description = "Example Description 3"
                },
                new Todo
                {
                    Id = 4,
                    Title = "Exmple 4",
                    Done = false,
                    CreatedAt = new DateTime(2024, 02, 27, 12, 16, 25).ToUniversalTime(),
                    Description = "Example Description 4"
                },
                new Todo
                {
                    Id = 5,
                    Title = "Exmple 5",
                    Done = false,
                    CreatedAt = new DateTime(2024, 02, 27, 12, 16, 25).ToUniversalTime(),
                    Description = "Example Description 5"
                },
                new Todo
                {
                    Id = 6,
                    Title = "Exmple 6",
                    Done = false,
                    CreatedAt = new DateTime(2024, 02, 27, 12, 16, 25).ToUniversalTime(),
                    Description = "Example Description 6"
                },
                new Todo
                {
                    Id = 7,
                    Title = "Exmple 7",
                    Done = false,
                    CreatedAt = new DateTime(2024, 02, 27, 12, 16, 25).ToUniversalTime(),
                    Description = "Example Description 7"
                },
                new Todo
                {
                    Id = 8,
                    Title = "Exmple 8",
                    Done = false,
                    CreatedAt = new DateTime(2024, 02, 27, 12, 16, 25).ToUniversalTime(),
                    Description = "Example Description 8"
                },
                new Todo
                {
                    Id = 9,
                    Title = "Exmple 9",
                    Done = false,
                    CreatedAt = new DateTime(2024, 02, 27, 12, 16, 25).ToUniversalTime(),
                    Description = "Example Description 9"
                },
                new Todo
                {
                    Id = 10,
                    Title = "Exmple 10",
                    Done = false,
                    CreatedAt = new DateTime(2024, 02, 27, 12, 16, 25).ToUniversalTime(),
                    Description = "Example Description 10"
                },
                new Todo
                {
                    Id = 11,
                    Title = "Exmple 11",
                    Done = false,
                    CreatedAt = new DateTime(2024, 02, 27, 12, 16, 25).ToUniversalTime(),
                    Description = "Example Description 11"
                },
                new Todo
                {
                    Id = 12,
                    Title = "Exmple 12",
                    Done = false,
                    CreatedAt = new DateTime(2024, 02, 27, 12, 16, 25).ToUniversalTime(),
                    Description = "Example Description 12"
                },
                new Todo
                {
                    Id = 13,
                    Title = "Exmple 13",
                    Done = false,
                    CreatedAt = new DateTime(2024, 02, 27, 12, 16, 25).ToUniversalTime(),
                    Description = "Example Description 13"
                },
                new Todo
                {
                    Id = 14,
                    Title = "Exmple 14",
                    Done = false,
                    CreatedAt = new DateTime(2024, 02, 27, 12, 16, 25).ToUniversalTime(),
                    Description = "Example Description 14"
                },
                new Todo
                {
                    Id = 15,
                    Title = "Exmple 15",
                    Done = false,
                    CreatedAt = new DateTime(2024, 02, 27, 12, 16, 25).ToUniversalTime(),
                    Description = "Example Description 15"
                });
        }
    }
}
