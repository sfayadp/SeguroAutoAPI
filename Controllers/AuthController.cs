
using Microsoft.AspNetCore.Mvc;
using SeguroAutoAPI.Application.Contracts;

namespace SeguroAutoAPI.Controllers
{
    // Controllers/AuthController.cs
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {

        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        

        [HttpPost]
        [Route(nameof(AuthController.Login))]
        public IActionResult Login(string username, string password)
        {
            return _authService.Login(username, password);
        }
    }


}
