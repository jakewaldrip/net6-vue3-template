using System.ComponentModel.DataAnnotations;

namespace sil_backend.Models.Requests
{
    public class GetUser
    {
        [Required]
        public int Id {  get; set; }
    }
}
