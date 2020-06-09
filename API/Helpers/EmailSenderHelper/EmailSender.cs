using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using System.Threading.Tasks;

namespace API.Helpers.EmailSenderHelper
{
    public class EmailSender : IEmailSenderHelper
    {


        public async Task SendRegistrationSuccessfulInfo(string emailAddress)
        {
            var message = PrepareSuccessfulRegistationMessage(emailAddress);
            await SendMessage(message);
        }


        private MimeMessage PrepareSuccessfulRegistationMessage(string email)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Video App Staff", "videoapp11121@gmail.com"));
            message.To.Add(new MailboxAddress("New user", email));
            message.Subject = "Successful Registration";
            message.Body = new TextPart
            {
                Text = "Your account has been created!!!"
            };
            return message;
        }

        private async Task SendMessage(MimeMessage message)
        {
            using (var smtp = new SmtpClient())
            {
                smtp.ServerCertificateValidationCallback = (s, c, h, e) => true;

                await smtp.ConnectAsync("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
                await smtp.AuthenticateAsync("videoapp11121@gmail.com", "VideoApp198");
                await smtp.SendAsync(message);
                await smtp.DisconnectAsync(true);
            }
        }
    }
}
