using Microsoft.AspNetCore.Mvc;
using sil_backend.Helpers;
using sil_backend.Models;
using sil_backend.Services;

namespace sil_backend.Controllers
{
    public class TestResponse
    {
        public string Name { get; set; }
    }

    [ApiController]
    [Route("api/[controller]")]
    public class HelloWorldController : ControllerBase
    {
        private readonly ILogger<HelloWorldController> _logger;
        private readonly IUserService _userService;

        public HelloWorldController(
            ILogger<HelloWorldController> logger,
            IUserService userService)
        {
            _userService = userService;
            _logger = logger;
        }

        [Authorize]
        [HttpGet(Name = "GetName")]
        public async Task<IActionResult> Get()
        {
            // test user creation in database
            var initialUser = new User
            {
                Name = "Bob Johnson",
                Email = "bobby@johnson.com",
                Password = "billy"
            };

            var existingUser = _userService.GetByEmail(initialUser.Email);
            if(existingUser is null)
            {
                await _userService.CreateUserAccount(initialUser);
            }
            
            var newUser = await _userService.GetByEmail(initialUser.Email);

            var name = new TestResponse
            {
                Name = newUser is not null ? newUser.Name : ""
            };

            return Ok(name);
        }
    }
}