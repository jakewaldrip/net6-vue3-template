using System.ComponentModel.DataAnnotations;

namespace sil_backend.Models.Requests
{
    public class UpdateUserProfile
    {
        [Required]
        public int Id { get; set; } 
        [Required]
        public string Email { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string TwitterHandle { get; set; }
    }
}
