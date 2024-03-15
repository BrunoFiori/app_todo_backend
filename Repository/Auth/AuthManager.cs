using AutoMapper;
using App_Todo_Backend.Contract.Users;
using App_Todo_Backend.Models.User;
using Microsoft.AspNetCore.Identity;
using App_Todo_Backend.Data;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;

namespace App_Todo_Backend.Repository.Auth
{
    public class AuthManager : IAuthManager
    {
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _configuration;
        public AuthManager(IMapper mapper, UserManager<User> userManager, IConfiguration configuration)
        {
            _mapper = mapper;
            _userManager = userManager;
            _configuration = configuration;
        }

        public async Task<AuthResponse> Login(LoginUser inputUser)
        {
            var user = await _userManager.FindByEmailAsync(inputUser.Email);
            if (user != null)
            {
                if (await _userManager.CheckPasswordAsync(user, inputUser.Password))
                {
                    var token = await GenerateToken(user);
                    return new AuthResponse { UserId = user.Id, Token = token };
                }
            }
            return null;
        }

        public async Task<IEnumerable<IdentityError>> Register(InputUser inputUser)
        {
            var user = _mapper.Map<User>(inputUser);
            var result = await _userManager.CreateAsync(user, inputUser.Password);

            //Defult Role for new user
            if (result.Succeeded)
                await _userManager.AddToRoleAsync(user, "User");

            return result.Errors;
        }
        private async Task<string> GenerateToken(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));

            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var roles = await _userManager.GetRolesAsync(user);
            var rolesClaims = roles.Select(role => new Claim(ClaimTypes.Role, role)).ToList();
            var userClaims = await _userManager.GetClaimsAsync(user);

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.NameId, user.Id)
            }
            .Union(userClaims)
            .Union(rolesClaims);

            var token = new JwtSecurityToken(
                               issuer: _configuration["Jwt:Issuer"],
                               audience: _configuration["Jwt:Audience"],
                               claims: claims,
                               expires: DateTime.Now.AddMinutes(Convert.ToInt32(_configuration["Jwt:DurationInMinutes"])),
                               signingCredentials: credentials
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
