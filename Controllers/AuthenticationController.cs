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
        private readonly ILogger<AuthenticationController> _logger;

        public AuthenticationController(IAuthManager authManager, ILogger<AuthenticationController> logger)
        {
            _authManager = authManager;
            _logger = logger;
        }

        [HttpPost]
        [Route("register")]
        [Authorize(Roles = "Administrator")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]//potential return 400 reutrn type
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]//potential return 500 reutrn type
        [ProducesResponseType(StatusCodes.Status200OK)]//potential return 200 reutrn type
        public async Task<IActionResult> Register([FromBody] InputUser inputUser)
        {
            _logger.LogInformation($"Registering user {inputUser.Email}");
            var result = await _authManager.Register(inputUser);
            if (result.Any())
                return BadRequest(result);
            _logger.LogInformation($"User {inputUser.Email} registered successfully");
            return Ok();
        }

        [HttpGet]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]//potential return 400 reutrn type
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]//potential return 500 reutrn type
        [ProducesResponseType(StatusCodes.Status200OK)]//potential return 200 reutrn type
        public async Task<IActionResult> GetByEmail(string email)
        {
            var result = await _authManager.GetByEmail(email);            
            return Ok(result);
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
