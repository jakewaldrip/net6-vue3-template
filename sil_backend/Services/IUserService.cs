namespace sil_backend.Services;

using sil_backend.Models;
using sil_backend.Models.Requests;
using sil_backend.Models.Responses;

public interface IUserService
{
    Task<AuthenticateResponse?> Authenticate(AuthenticateRequest model);
    Task<int> CreateUserAccount(User user);
    Task<User?> GetByEmail(string email);
    Task<User?> GetById(int id);
    Task<int> SaveUserProfileChange(UpdateUserProfile user);
    Task<int> SaveUserPasswordChange(int userId, string password);
    Task<int> SaveUserPasswordChange(string userEmail, string password);
}