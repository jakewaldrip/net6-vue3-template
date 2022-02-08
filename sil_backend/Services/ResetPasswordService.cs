using Microsoft.Extensions.Options;
using sil_backend.Helpers;
using sil_backend.Models;
using sil_backend.Models.Requests;
using sil_backend.Repositories;

namespace sil_backend.Services
{
    public class ResetPasswordService : IResetPasswordService
    {
        private readonly IResetPasswordRepository _resetPasswordRepository;
        private readonly IUserRepository _userRepository;
        private readonly IEmailService _emailService;
        private readonly MailSettings _mailSettings;

        public ResetPasswordService(
            IResetPasswordRepository resetPasswordRepository,
            IUserRepository userRepository, 
            IEmailService emailService,
            IOptions<MailSettings> mailSettings)
        {
            _resetPasswordRepository = resetPasswordRepository;
            _userRepository = userRepository;
            _emailService = emailService;
            _mailSettings = mailSettings.Value;
        }

        public async Task<string> CreatePasswordResetSession(string userEmail)
        {
            var user = await _userRepository.GetUserByEmail(userEmail);
            if(user is null)
            {
                return string.Empty;
            }

            await DeleteAllPasswordResetSessionsForUser(user);
            return await _resetPasswordRepository.CreatePasswordResetSession(user);
        }

        public async Task<ResetPassword?> GetPasswordResetSessionForUser(string userEmail)
        {
            var user = await _userRepository.GetUserByEmail(userEmail);
            if (user is null)
            {
                return null;
            }

            return await _resetPasswordRepository.GetPasswordResetSessionForUser(user);
        }

        public async Task SendResetPasswordEmail(string userEmail, string token)
        {
            var mailRequest = new MailRequest
            {
                Subject = $"{_mailSettings.DisplayName} Password Reset",
                Body = $"Security Key - {token}",
                ToEmail = userEmail
            };

            await _emailService.SendEmailAsync(mailRequest);
        }

        public async Task<bool> VerifyToken(string token, string userEmail)
        {
            var user = await _userRepository.GetUserByEmail(userEmail);
            if (user is null)
            {
                return false;
            }

            var resetSession = await _resetPasswordRepository.GetPasswordResetSessionForUser(user);
            if(resetSession is not null && resetSession.Token.Equals(token))
            {
                await DeleteAllPasswordResetSessionsForUser(user);
                return true;
            }

            return false;
        }

        private async Task<int> DeleteAllPasswordResetSessionsForUser(User user)
        {
            return await _resetPasswordRepository.DeleteAllPasswordResetSessionsForUser(user);
        }
    }
}
