using Microsoft.AspNetCore.Identity;

namespace App_Todo_Backend.Data.Models
{
    public class User : IdentityUser
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
    }
}