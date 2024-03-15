using App_Todo_Backend.Contract.Users;
using App_Todo_Backend.Models.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace App_Todo_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        public readonly IAuthManager _authManager;
        public AuthenticationController(IAuthManager authManager)
        {
            _authManager = authManager;
        }

        [HttpPost]
        [Route("register")]
        [Authorize(Roles = "Administrator")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]//potential return 400 reutrn type
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]//potential return 500 reutrn type
        [ProducesResponseType(StatusCodes.Status200OK)]//potential return 200 reutrn type
        public async Task<IActionResult> Register([FromBody] InputUser inputUser)
        {
            var result = await _authManager.Register(inputUser);
            if (result.Any())
                return BadRequest(result);
            return Ok();
        }
        
        [HttpPost]
        [Route("login")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]//potential return 400 reutrn type
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]//potential return 500 reutrn type
        [ProducesResponseType(StatusCodes.Status200OK)]//potential return 200 reutrn type
        public async Task<IActionResult> Register([FromBody] LoginUser loginUser)
        {
            var result = await _authManager.Login(loginUser);
            if (result == null)
                return Unauthorized();
            return Ok(result);
        }

        [HttpPost]
        [Route("refreshtoken")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]//potential return 400 reutrn type
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]//potential return 500 reutrn type
        [ProducesResponseType(StatusCodes.Status200OK)]//potential return 200 reutrn type
        public async Task<IActionResult> RefreshToken([FromBody] AuthResponse authResponse)
        {
            var result = await _authManager.VerifyRefeshToken(authResponse);
            if (result == null)
                return Unauthorized();
            return Ok(result);
        }
    }
}
