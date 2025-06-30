using Microsoft.AspNetCore.Mvc;
using UserAuthApi.Services;
using Microsoft.Extensions.Logging;

namespace UserAuthApi.Controllers
{
    // Controller to handle HTTP requests for authentication
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;
        private readonly ILogger<AuthController> _logger;

        // Constructor with dependency injection of AuthService and Logger
        public AuthController(AuthService authService, ILogger<AuthController> logger)
        {
            _authService = authService;
            _logger = logger;
        }

        // Endpoint to register a new user
        // POST: /api/auth/register
        [HttpPost("register")]
        public IActionResult Register([FromQuery] string username, [FromQuery] string email, [FromQuery] string password)
        {
            try
            {
                bool result = _authService.CreateAccount(username, email, password);
                if (!result)
                {
                    return BadRequest("Registration failed. Username or email might already be in use.");
                }

                return Ok("Account created successfully.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unexpected error in Register.");
                return StatusCode(500, "Internal server error during registration.");
            }
        }

        // Endpoint to authenticate an existing user
        // POST: /api/auth/login
        [HttpPost("login")]
        public IActionResult Login([FromQuery] string username, [FromQuery] string password)
        {
            try
            {
                bool result = _authService.AuthenticateAccount(username, password);
                if (!result)
                {
                    return Unauthorized("Invalid username or password.");
                }

                return Ok($"Welcome, {username}!");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unexpected error in Login.");
                return StatusCode(500, "Internal server error during login.");
            }
        }
    }
}
