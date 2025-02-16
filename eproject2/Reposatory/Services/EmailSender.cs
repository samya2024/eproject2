using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using eproject2.ViewModels;
using System.Text;
using eproject2.Reposatory.Interface;

namespace eproject2.Reposatory.Services
{

    public class EmailSender : IEmailSender
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<EmailSender> _logger; // 🔹 Logger Add Kiya

        public EmailSender(IConfiguration configuration, ILogger<EmailSender> logger)
        {
            _configuration = configuration;
            _logger = logger;
        }

        public async Task<bool> SendEmailAsync(string email, string subject, string htmlMessage)
        {
            try
            {
                // 🔹 Fetch Configuration
                GetEmail getEmail = new GetEmail()
                {
                    EnableSsl = _configuration.GetValue<bool>("AppSetting:EmailSettings:EnableSsl"),
                    From = _configuration.GetValue<string>("AppSetting:EmailSettings:From"),
                    Port = _configuration.GetValue<int>("AppSetting:EmailSettings:Port"),
                    SmtpServer = _configuration.GetValue<string>("AppSetting:EmailSettings:SmtpServer"),
                 
                    SecretKey = _configuration.GetValue<string>("AppSetting:SecretKey")
                };

                // 🔹 Logging Configuration Details (Sensitive Data Hide Karein!)
                _logger.LogInformation("Starting Email Sending Process...");
                _logger.LogInformation($"SMTP Server: {getEmail.SmtpServer}");
                _logger.LogInformation($"Port: {getEmail.Port}");
                _logger.LogInformation($"Email: {getEmail.From}");

                var mailMessage = new MailMessage
                {
                    From = new MailAddress(getEmail.From),
                    Subject = subject,
                    Body = htmlMessage,
                    //BodyEncoding = Encoding.UTF8,
                    //IsBodyHtml = true
                };

                mailMessage.To.Add(email);

                // 🔹 SMTP Client Setup
                var smtpClient = new SmtpClient(getEmail.SmtpServer)
                {
                    Port = getEmail.Port,
                    Credentials = new NetworkCredential(getEmail.From, getEmail.SecretKey),
                    EnableSsl = getEmail.EnableSsl
                };

                // 🔹 Email Message
            

                // 🔹 Send Email
                await smtpClient.SendMailAsync(mailMessage);
                _logger.LogInformation("✅ Email Sent Successfully!");

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"❌ Email Sending Failed: {ex.Message}");
                return false;
            }
        }
    }
}
