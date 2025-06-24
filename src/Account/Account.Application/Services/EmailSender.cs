
using System.Net.Mail;
using System.Net;
using Account.Application.Interfaces;
using Microsoft.Extensions.Configuration;

namespace Acccount.Application.Services
{
    public class EmailSender : IEmailSender
    {
        
             private readonly IConfiguration _configuration;

        public EmailSender(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task SendEmailAsync(string email, string subject, string message)
        {
            var mailSettings = _configuration.GetSection("MailSettings");
            var client = new SmtpClient(mailSettings["Host"], int.Parse(mailSettings["Port"]))
            {
                Credentials = new NetworkCredential(mailSettings["Mail"], mailSettings["Password"]),
                EnableSsl = true
            };

            var mailMessage = new MailMessage
            {
                From = new MailAddress(mailSettings["Mail"], mailSettings["DisplayName"]),
                Subject = subject,
                Body = message,
                IsBodyHtml = true
            };

            mailMessage.To.Add(email);

            await client.SendMailAsync(mailMessage);
        }
    
    }
}
