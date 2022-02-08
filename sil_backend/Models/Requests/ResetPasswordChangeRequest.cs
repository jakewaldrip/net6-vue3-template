using System.ComponentModel.DataAnnotations;

namespace sil_backend.Models.Requests
{
    public class ResetPasswordChangeRequest
    {
        [Required]
        public string UserEmail { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
