using System.ComponentModel.DataAnnotations;

namespace App_Todo_Backend.Models.User
{
    public class UpdateUser : BaseUserDto
    {        
        public string HashPassword { get; set; }        
    }
}
