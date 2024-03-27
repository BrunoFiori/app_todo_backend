using App_Todo_Backend.Configurations;
using System.ComponentModel.DataAnnotations;

namespace App_Todo_Backend.Models.User
{
    public class OutputUser
    {        
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}