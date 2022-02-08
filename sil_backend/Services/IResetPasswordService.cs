using sil_backend.Models;

namespace sil_backend.Services
{
    public interface IResetPasswordService
    {
        Task<string> CreatePasswordResetSession(string userEmail);
        Task<ResetPassword?> GetPasswordResetSessionForUser(string userEmail);
        Task<bool> VerifyToken(string token, string userEmail);
        Task SendResetPasswordEmail(string userEmail, string token);
    }
}
