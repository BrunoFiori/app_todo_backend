namespace App_Todo_Backend.Core.Models
{
    public class AuthResponse
    {
        public required string UserId { get; set; }
        public required string Token { get; set; }
        public string? RefreshToken { get; set; }        
    }
}
