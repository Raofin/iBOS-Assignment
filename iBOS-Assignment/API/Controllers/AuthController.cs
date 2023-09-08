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

        public AuthController(AuthService authService)
        {
            _authService = authService;
        }

        [AllowAnonymous]
        [HttpGet("GetToken")]
        public IActionResult Auth()
        {
            return Ok(_authService.Generate());
        }
    }
}
