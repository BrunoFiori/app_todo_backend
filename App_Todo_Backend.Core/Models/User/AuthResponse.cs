namespace App_Todo_Backend.Core.Models.User
{
    public class AuthResponse
    {
        public string UserId { get; set; }
        public string Token { get; set; }
        public string RefreshToken { get; set; }        
    }
}
