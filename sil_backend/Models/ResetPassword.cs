namespace sil_backend.Models
{
    public class ResetPassword
    {
        public int Id { get; set; }
        public string Token { get; set; }
        public string UserEmail { get; set; }
    }
}
