using Microsoft.Extensions.Options;
using sil_backend.Helpers;
using sil_backend.Models.Requests;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using System.Linq;

namespace sil_backend.Services
{
    public class EmailService : IEmailService
    {
        private readonly MailSettings _mailSettings;
        public EmailService(IOptions<MailSettings> mailSettings)
        {
            _mailSettings = mailSettings.Value;
        }

        public async Task SendEmailAsync(MailRequest mailRequest)
        {
            var email = new MimeMessage
            {
                Sender = MailboxAddress.Parse(_mailSettings.Mail),
                Subject = mailRequest.Subject
            };
            email.To.Add(MailboxAddress.Parse(mailRequest.ToEmail));
            
            var builder = new BodyBuilder();
            if (mailRequest.Attachments != null)
            {
                byte[] fileBytes;
                foreach (var file in from file 
                        in mailRequest.Attachments
                        where file.Length > 0
                        select file)
                {
                    using (var ms = new MemoryStream())
                    {
                        file.CopyTo(ms);
                        fileBytes = ms.ToArray();
                    }

                    builder.Attachments.Add(file.FileName, fileBytes, ContentType.Parse(file.ContentType));
                }
            }
            builder.HtmlBody = mailRequest.Body;
            email.Body = builder.ToMessageBody();
            using var smtp = new SmtpClient();
            smtp.Connect(_mailSettings.Host, _mailSettings.Port, SecureSocketOptions.StartTls);
            smtp.Authenticate(_mailSettings.Mail, _mailSettings.Password);
            await smtp.SendAsync(email);
            smtp.Disconnect(true);
        }
    }
}
