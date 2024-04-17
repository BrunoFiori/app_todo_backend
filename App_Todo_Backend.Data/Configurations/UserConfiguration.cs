using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App_Todo_Backend.Data.Configurations { 
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData(
                new User
                {
                    Id = "bdf86add-3709-4252-8fcd-g8h13029cceb",
                    UserName = "Administrator",
                    NormalizedUserName = "ADMINISTRATOR",
                    Email = "admin@gmail.com",
                    NormalizedEmail = "ADMIN@GMAIL.COM",
                    EmailConfirmed = true,
                    PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, "P@assword1"), // Defina a senha aqui
                    SecurityStamp = string.Empty,
                    FirstName = "Admin",
                    LastName = "Admin"
                }                
            );
        }
    }
}
