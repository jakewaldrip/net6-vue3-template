using System.ComponentModel.DataAnnotations;

namespace sil_backend.Models.Requests
{
    public class ResetPasswordRequest
    {
        [Required]
        public string UserEmail { get; set; }
    }
}
