using App_Todo_Backend.Core.Configurations;
using System.ComponentModel.DataAnnotations;

namespace App_Todo_Backend.Core.Models.User
{
    public class InputUser : LoginUser
    {        
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
    }
}