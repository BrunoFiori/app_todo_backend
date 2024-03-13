using AutoMapper;
using App_Todo_Backend.Contract.Users;
using App_Todo_Backend.Models.User;
using Microsoft.AspNetCore.Identity;
using App_Todo_Backend.Data;

namespace App_Todo_Backend.Repository.Auth
{
    public class AuthManager : IAuthManager
    {
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        public AuthManager(IMapper mapper, UserManager<User> userManager)
        {
            _mapper = mapper;
            _userManager = userManager; 
        }

        public async Task<IEnumerable<IdentityError>> Register(InputUser inputUser)
        {
            var user = _mapper.Map<User>(inputUser);            
            // user.UserName = inputUser.Email; - caso o mapper n de certo
            var result = await _userManager.CreateAsync(user, inputUser.Password);
            
            //Defult Role for new user
            if (result.Succeeded)
                await _userManager.AddToRoleAsync(user, "User");

            return result.Errors;
        }
    }
}
