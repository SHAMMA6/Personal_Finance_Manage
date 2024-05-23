using ApplicationLayer.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructurLayer.Services
{
    public class EmailService : IEmailService
    {
        public Task SendEmailAsync(string to, string subject, string message)
        {
            var smtpClient = new SmtpClient("smtp.your-email-provider.com")
            {
                Port = 587,
                Credentials = new System.Net.NetworkCredential("your-email@example.com", "your-email-password"),
                EnableSsl = true,
            };

            var mailMessage = new MailMessage
            {
                From = new MailAddress("your-email@example.com"),
                Subject = subject,
                Body = message,
                IsBodyHtml = false,
            };

            mailMessage.To.Add(to);

            smtpClient.Send(mailMessage);

            return Task.CompletedTask;
        }
    }
}
