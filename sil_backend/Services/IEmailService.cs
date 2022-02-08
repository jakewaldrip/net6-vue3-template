using sil_backend.Models.Requests;

namespace sil_backend.Services
{
    public interface IEmailService
    {
        Task SendEmailAsync(MailRequest mailRequest);
    }
}
