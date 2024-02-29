using System.ComponentModel.DataAnnotations;

namespace App_Todo_Backend.Models.User
{
    public class CreateUser : BaseUserDto
    {        
        [Required]
        public string HashPassword { get; set; }        
    }
}
