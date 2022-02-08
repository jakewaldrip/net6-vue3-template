using Microsoft.EntityFrameworkCore;
using sil_backend.Models;

namespace sil_backend.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly MyDbContext _context;

        public UserRepository(MyDbContext context)
        {
            _context = context;
        }

        public async Task<int> CreateUser(User user)
        {
            _context.Users.Add(user);
            return await _context.SaveChangesAsync();
        }

        public async Task<User?> GetUserByEmail(string email)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(x => x.Email == email);
            
            if(user == null)
            {
                return null;     
            }
            return user;
        }

        public async Task<User?> GetUserByName(string name)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(x => x.Name == name);

            if (user == null)
            {
                return null;
            }
            return user;
        }

        public async Task<User?> GetUserById(int id)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(x => x.Id == id);

            if (user == null)
            {
                return null;
            }
            return user;
        }

        public async Task<int> UpdateUser(User newUser)
        {
            if (newUser == null)
            {
                return 0;
            }

            var user = await _context.Users
                .FirstOrDefaultAsync(x => x.Id == newUser.Id);

            if(user == null)
            {
                return 0;
            }

            user.Email = newUser.Email;
            user.Name = newUser.Name;
            user.Password = newUser.Password;
            user.TwitterHandle = newUser.TwitterHandle;
            return await _context.SaveChangesAsync();
        }
    }
}
