using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using MimeKit.Text;

namespace Web.EmailService
{
    public interface IEmailService
    {
        void SendEmail(EmailDTO request);
    }
}