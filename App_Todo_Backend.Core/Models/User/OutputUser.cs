using App_Todo_Backend.Core.Configurations;
using System.ComponentModel.DataAnnotations;

namespace App_Todo_Backend.Core.Models.User
{
    public class OutputUser
    {        
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}