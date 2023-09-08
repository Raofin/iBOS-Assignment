using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using iBOS_Assignment.BLL.Services;

namespace iBOS_Assignment.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;

        // Constructor for the AuthController class, which injects an instance of AuthService.
        public AuthController(AuthService authService)
        {
            _authService = authService;
        }

        // Generate and return an authentication token.
        [AllowAnonymous] // Allow access to this endpoint without authentication.
        [HttpGet("GetToken")] // Specify the HTTP method and route for this action.
        public IActionResult Auth()
        {
            // Call the AuthService to generate an authentication token.
            return Ok(_authService.Generate());
        }
    }
}
