using System.ComponentModel.DataAnnotations;

namespace sil_backend.Models.Requests
{
    public class RegisterUser
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string TwitterHandle { get; set; }
    }
}
