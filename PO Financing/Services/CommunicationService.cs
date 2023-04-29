using SendGrid;
using SendGrid.Helpers.Mail;
using System.Threading.Tasks;

namespace PO_Financing.Services
{
    public class CommunicationService : ICommunicationService
    {
        private readonly string _sendgridApiKey;

        public CommunicationService()
        {
            _sendgridApiKey = "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";
        }

        public async Task<Response> SendEmailAsync(string recepientEmail, string senderEmail, string senderName, string recepientName, string subject, string body)
        {
            var client = new SendGridClient(_sendgridApiKey);
            var msg = new SendGridMessage()
            {
                From = new EmailAddress(senderEmail, senderName),
                Subject = subject,
                PlainTextContent = body
            };
            msg.AddTo(new EmailAddress(recepientEmail, recepientName));
            return await client.SendEmailAsync(msg);
        }
    }
}
