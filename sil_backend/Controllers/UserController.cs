using Microsoft.AspNetCore.Mvc;
using sil_backend.Helpers;
using sil_backend.Models;
using sil_backend.Models.Requests;
using sil_backend.Services;

namespace sil_backend.Controllers
{
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [Authorize]
        [HttpPost("api/[controller]", Name = "GetUser")]
        public async Task<IActionResult> GetUser(GetUser model)
        {
            var response = await _userService.GetById(model.Id);

            if(response is null)
            {
                return NoContent();
            }

            return Ok(response);
        }

        [HttpPost("api/[controller]/authenticate", Name = "Authenticate")]
        public async Task<IActionResult> Authenticate(AuthenticateRequest model)
        {
            var response = await _userService.Authenticate(model);

            if (response == null)
            {
                return Unauthorized(new { message = "Username or password is incorrect" });
            }

            return Ok(response);
        }

        [HttpPost("api/[controller]/register", Name = "Register")]
        public async Task<IActionResult> Register(RegisterUser model)
        {
            var response = await _userService.CreateUserAccount(new User
            {
                Email = model.Email,
                Name = model.Name,
                Password = model.Password,
                TwitterHandle = model.TwitterHandle
            });

            if(response == 0)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [Authorize]
        [HttpPost("api/[controller]/profile", Name = "UpdateProfile")]
        public async Task<IActionResult> UpdateProfile(UpdateUserProfile model)
        {
            var response = await _userService.SaveUserProfileChange(model);
            if (response == 0)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [Authorize]
        [HttpPost("api/[controller]/password", Name = "ChangePassword")]
        public async Task<IActionResult> ChangePassword(UpdateUserPassword model)
        {
            var response = await _userService.SaveUserPasswordChange(model.userId, model.Password);
            if (response == 0)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }
    }
}
