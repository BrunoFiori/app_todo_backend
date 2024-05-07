namespace App_Todo_Backend.Core.Models
{
    public class OutputUser
    {        
        public required string FirstName { get; set; }
        public string? LastName { get; set; }
        public required string Email { get; set; }
    }
}