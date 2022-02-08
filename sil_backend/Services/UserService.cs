namespace sil_backend.Services;

using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using sil_backend.Helpers;
using sil_backend.Models;
using sil_backend.Models.Requests;
using sil_backend.Models.Responses;
using sil_backend.Repositories;
using BCrypt.Net;

public class UserService : IUserService
{
    private readonly AppSettings _appSettings;
    private readonly IUserRepository _userRepository;

    public UserService(IOptions<AppSettings> appSettings, IUserRepository userRepository)
    {
        _appSettings = appSettings.Value;
        _userRepository = userRepository;
    }

    public async Task<AuthenticateResponse?> Authenticate(AuthenticateRequest model)
    {
        var user = await GetByEmail(model.Email);

        if (user == null)
        {
            return null;
        }

        if(!BCrypt.Verify(model.Password, user.Password))
        {
            return null;
        }

        var token = GenerateJwtToken(user);
        return new AuthenticateResponse(user, token);
    }

    public async Task<User?> GetByEmail(string email)
    {
        return await _userRepository.GetUserByEmail(email);
    }

    public async Task<User?> GetById(int id)
    {
        return await _userRepository.GetUserById(id);
    }

    public async Task<int> CreateUserAccount(User user)
    {
        var existingUser = await GetByEmail(user.Email);
        if(existingUser is not null)
        {
            return 0;
        }

        user.Password = BCrypt.HashPassword(user.Password);

        return await _userRepository.CreateUser(user);
    }

    public async Task<int> SaveUserProfileChange(UpdateUserProfile user)
    {
        var existingUser = await _userRepository.GetUserById(user.Id);
        if (existingUser is null)
        {
            return 0;
        }

        existingUser.Email = user.Email;
        existingUser.Name = user.Name;
        existingUser.TwitterHandle = user.TwitterHandle;
        return await _userRepository.UpdateUser(existingUser);
    }

    public async Task<int> SaveUserPasswordChange(int userId, string password)
    {
        var existingUser = await _userRepository.GetUserById(userId);
        if(existingUser is null)
        {
            return 0;
        }

        existingUser.Password = BCrypt.HashPassword(password);
        return await _userRepository.UpdateUser(existingUser);
    }

    public async Task<int> SaveUserPasswordChange(string userEmail, string password)
    {
        var existingUser = await _userRepository.GetUserByEmail(userEmail);
        if (existingUser is null)
        {
            return 0;
        }

        existingUser.Password = BCrypt.HashPassword(password);
        return await _userRepository.UpdateUser(existingUser);
    }

    private string GenerateJwtToken(User user)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_appSettings.JwtSecret);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
            Expires = DateTime.UtcNow.AddDays(7),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}