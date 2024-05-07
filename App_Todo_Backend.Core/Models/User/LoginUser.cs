using App_Todo_Backend.Core.Configurations;
using System.ComponentModel.DataAnnotations;

namespace App_Todo_Backend.Core.Models
{
    public class LoginUser
    {
        [Required]        
        [EmailAddress]
        public required string Email { get; set; }
        [Required]
        [SecurePassword]
        public required string Password { get; set; }
    }
}