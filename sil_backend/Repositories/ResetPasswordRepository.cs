using Microsoft.EntityFrameworkCore;
using sil_backend.Models;

namespace sil_backend.Repositories
{
    public class ResetPasswordRepository : IResetPasswordRepository
    {
        private readonly MyDbContext _context;

        public ResetPasswordRepository(MyDbContext context)
        {
            _context = context;
        }

        public async Task<string> CreatePasswordResetSession(User user)
        {
            Random r = new();
            var tokenIntValue = r.Next(0, 1000000);
            string token = tokenIntValue.ToString("000000");

            var passwordResetSession = new ResetPassword
            {
                UserEmail = user.Email,
                Token = token
            };

            _context.ResetPassword.Add(passwordResetSession);
            await _context.SaveChangesAsync();
            return token;
        }

        public async Task<int> DeleteAllPasswordResetSessionsForUser(User user)
        {
            var resetSessions = _context.ResetPassword
                .Where(s => s.UserEmail == user.Email)
                .ToList();
            _context.ResetPassword.RemoveRange(resetSessions);
            return await _context.SaveChangesAsync();
        }

        public async Task<ResetPassword?> GetPasswordResetSessionForUser(User user)
        {
            return await _context.ResetPassword
                .FirstOrDefaultAsync(x => x.UserEmail == user.Email);
        }
    }
}
