using iBOS_Assignment.BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace iBOS_Assignment.API.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        // Constructor for the AuthController class, which injects an instance of AuthService.
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        // Generate and return an authentication token.
        [AllowAnonymous] // Allow access to this endpoint without authentication.
        [HttpGet("get-token")] // Specify the HTTP method and route for this action.
        public IActionResult Auth()
        {
            // Call the AuthService to generate an authentication token.
            return Ok(_authService.Generate());
        }
    }
}
