using SendGrid;
using System.Threading.Tasks;

namespace PO_Financing.Services
{
    public interface ICommunicationService
    {
        public Task<Response> SendEmailAsync(string recepientEmail, string senderEmail, string senderName, string recepientName, string subject, string body);
    }
}
