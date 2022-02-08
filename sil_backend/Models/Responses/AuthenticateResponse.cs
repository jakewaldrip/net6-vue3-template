namespace sil_backend.Models.Responses;

using sil_backend.Models;

public class AuthenticateResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string TwitterHandle { get; set; }
    public string Token { get; set; }


    public AuthenticateResponse(User user, string token)
    {
        Id = user.Id;
        Name = user.Name;
        Email = user.Email;
        TwitterHandle = user.TwitterHandle;
        Token = token;
    }
}