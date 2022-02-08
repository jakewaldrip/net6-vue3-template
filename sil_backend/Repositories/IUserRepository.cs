using sil_backend.Models;

namespace sil_backend.Repositories
{
    public interface IUserRepository
    {
        Task<int> CreateUser(User user);
        Task<User?> GetUserByName(string name);
        Task<User?> GetUserByEmail(string email);
        Task<User?> GetUserById(int id);
        Task<int> UpdateUser(User newUser);
    }
}