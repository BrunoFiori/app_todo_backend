using App_Todo_Backend.Configurations;
using System.ComponentModel.DataAnnotations;

namespace App_Todo_Backend.Models.User
{
    public class LoginUser
    {
        [Required]        
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [SecurePassword]
        public string Password { get; set; }
    }
}