using App_Todo_Backend.Models.User;
using Microsoft.AspNetCore.Identity;

namespace App_Todo_Backend.Contract.Users
{
    public interface IAuthManager
    {
        Task<IEnumerable<IdentityError>> Register(InputUser inputUser);

        Task<AuthResponse> Login(LoginUser inputUser);
        
    }
}
