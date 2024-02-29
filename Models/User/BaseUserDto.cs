using System.ComponentModel.DataAnnotations;

namespace App_Todo_Backend.Models.User
{
    public abstract class BaseUserDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        public string Avatar { get; set; }
    }
}
