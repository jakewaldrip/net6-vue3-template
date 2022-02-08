using System.ComponentModel.DataAnnotations;

namespace sil_backend.Models.Requests
{
    public class UpdateUserPassword
    {
        public int userId { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
