using Microsoft.AspNetCore.Mvc;
using sil_backend.Models.Requests;
using sil_backend.Services;

namespace sil_backend.Controllers
{
    [ApiController]
    public class ResetPasswordController : ControllerBase
    {
        private readonly IResetPasswordService _resetPasswordService;
        private readonly IUserService _userService;

        public ResetPasswordController(IResetPasswordService resetPasswordService, IUserService userService)
        {
            _resetPasswordService = resetPasswordService;
            _userService = userService;
        }

        [HttpPost("api/[controller]/create", Name = "CreateResetPasswordSession")]
        public async Task<IActionResult> CreateResetPasswordSession(ResetPasswordRequest model)
        {
            var token = await _resetPasswordService.CreatePasswordResetSession(model.UserEmail);

            if(token == string.Empty)
            {
                return NotFound();
            }

            await _resetPasswordService.SendResetPasswordEmail(model.UserEmail, token);

            return Ok();
        }

        [HttpPost("api/[controller]/verify", Name = "VerifyResetPasswordSession")]
        public async Task<IActionResult> VerifyResetPasswordSession(ResetPasswordVerifyRequest model)
        {
            var response = await _resetPasswordService.VerifyToken(model.Token, model.UserEmail);
            return Ok(response);
        }

        [HttpPost("api/[controller]/change", Name = "ChangePasswordResetSession")]
        public async Task<IActionResult> ChangePasswordResetSession(ResetPasswordChangeRequest model)
        {
            var response = await _userService.SaveUserPasswordChange(model.UserEmail, model.Password);
            return Ok(response);
        }
    }
}
