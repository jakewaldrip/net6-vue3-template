using sil_backend.Models;

namespace sil_backend.Repositories
{
    public interface IResetPasswordRepository
    {
        Task<string> CreatePasswordResetSession(User user);
        Task<int> DeleteAllPasswordResetSessionsForUser(User user);
        Task<ResetPassword?> GetPasswordResetSessionForUser(User user);
    }
}
