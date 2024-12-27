using Microsoft.AspNetCore.Mvc;

namespace AI_driven_OSINT_platform.Backend.Features.Authentication.API.Controllers
{
    /// <summary>
    /// Handles authentication-related operations such as login and registration.
    /// </summary>
    [ApiController]
    [Route("api/auth")]
    public class AuthenticationController : ControllerBase
    {
        /// <summary>
        /// Authenticates a user and returns a JWT token upon successful validation.
        /// </summary>
        /// <param name="request">The login request containing username and password.</param>
        /// <returns>A JWT token if the credentials are valid, or an error message if validation fails.</returns>
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            // Validate request payload.
            if (string.IsNullOrWhiteSpace(request.Username) || string.IsNullOrWhiteSpace(request.Password))
            {
                // Return bad request if username or password is missing.
                return BadRequest(new { Message = "Username and password are required." });
            }

            // TODO: Add logic to validate user credentials and issue a JWT.

            // Simulate a successful login response with a placeholder token.
            return Ok(new { Token = "sample_jwt_token" });
        }

        /// <summary>
        /// Registers a new user in the system.
        /// </summary>
        /// <param name="request">The registration request containing user details.</param>
        /// <returns>A confirmation message upon successful registration, or an error message if validation fails.</returns>
        [HttpPost("register")]
        public IActionResult Register([FromBody] RegisterRequest request)
        {
            // Validate request payload.
            if (string.IsNullOrWhiteSpace(request.Username) || string.IsNullOrWhiteSpace(request.Password) || string.IsNullOrWhiteSpace(request.Email))
            {
                // Return bad request if any required field is missing.
                return BadRequest(new { Message = "Username, password, and email are required." });
            }

            // TODO: Add logic to create a new user in the database.

            // Simulate a successful registration response.
            return Ok(new { Message = "User registered successfully." });
        }
    }

    /// <summary>
    /// Represents the payload for a login request.
    /// </summary>
    public class LoginRequest
    {
        /// <summary>
        /// Gets or sets the username for login.
        /// </summary>
        public string Username { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the password for login.
        /// </summary>
        public string Password { get; set; } = string.Empty;
    }

    /// <summary>
    /// Represents the payload for a registration request.
    /// </summary>
    public class RegisterRequest
    {
        /// <summary>
        /// Gets or sets the username for registration.
        /// </summary>
        public string Username { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the password for registration.
        /// </summary>
        public string Password { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the email for registration.
        /// </summary>
        public string Email { get; set; } = string.Empty;
    }
}
