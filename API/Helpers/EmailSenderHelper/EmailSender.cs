using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using System.Threading.Tasks;

namespace API.Helpers.EmailSenderHelper
{
    public class EmailSender : IEmailSenderHelper
    {

        public async Task SendRegisterConfirmationEmail(string email, string token)
        {
            var message = PrepareConfirmRegistrationMessage(email, token);
            await SendMessage(message);
        }

        private MimeMessage PrepareConfirmRegistrationMessage(string email, string token)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Staff", ""));
            message.To.Add(new MailboxAddress("New user", email));
            message.Subject = "Confirm your account";
            message.Body = new TextPart
            {
                Text = "Paste this url in new widnow to confirm your registratnion: " + token
            };
            return message;
        }

        private async Task SendMessage(MimeMessage message)
        {
            using (var smtp = new SmtpClient())
            {
                smtp.ServerCertificateValidationCallback = (s, c, h, e) => true;

                await smtp.ConnectAsync("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
                await smtp.AuthenticateAsync("", "");
                await smtp.SendAsync(message);
                await smtp.DisconnectAsync(true);
            }
        }
    }
}
