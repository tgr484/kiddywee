using Kiddywee.BLL.Core;
using Kiddywee.BLL.Interfaces;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Kiddywee.BLL.Repositories
{
    public class EmailSender : IEmailSender
    {
        private readonly IOptions<EmailSettings> _emailSettings;

        public EmailSender(IOptions<EmailSettings> emailSettings)
        {
            _emailSettings = emailSettings;
        }

        public void SendEmail(string recipient, string subject, string body)
        {
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress(_emailSettings.Value.EmailSenderLogin, _emailSettings.Value.EmailSenderLogin));
            emailMessage.To.Add(new MailboxAddress("", recipient));
            emailMessage.Subject = subject;

            var multipart = new Multipart("mixed")
            {
                EmailBody(body),
            };
            emailMessage.Body = multipart;
            SendEmailAsync(emailMessage).RunSynchronously();
        }

        public async Task SendEmailAsync(string recipient, string subject, string body)
        {
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress(_emailSettings.Value.EmailSenderLogin, _emailSettings.Value.EmailSenderLogin));
            emailMessage.To.Add(new MailboxAddress("", recipient));
            emailMessage.Subject = subject;

            var multipart = new Multipart("mixed")
            {
                EmailBody(body),
            };
            emailMessage.Body = multipart;
            await SendEmailAsync(emailMessage);
        }

        private async Task SendEmailAsync(MimeMessage emailMessage)
        {
            using var client = new SmtpClient();
            try
            {
                await client.ConnectAsync(_emailSettings.Value.EmailSenderSmtpServer, _emailSettings.Value.EmailSenderPort, _emailSettings.Value.EmailSenderEnableSsl);
                await client.AuthenticateAsync(_emailSettings.Value.EmailSenderLogin, _emailSettings.Value.EmailSenderPassword);
                await client.SendAsync(emailMessage);

                await client.DisconnectAsync(true);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        private TextPart EmailBody(string text)
        {
            var result = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = text
            };
            return result;
        }
    }
}
