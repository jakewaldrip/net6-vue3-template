using System.ComponentModel.DataAnnotations;

namespace sil_backend.Models.Requests
{
    public class ResetPasswordVerifyRequest
    {
        [Required]
        public string Token { get; set; }
        [Required]
        public string UserEmail { get; set; }
    }
}
