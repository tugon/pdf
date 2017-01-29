using SendGrid;
using SendGrid.Helpers.Mail;
using System.Threading.Tasks;

namespace Helpers
{
    public class SendGridHelper
    {
        const string _apiKey = "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";
        public SendGridHelper()
        {

        }

        public async Task Send(string from, string to,string subject, string message)        {
            
            dynamic sg = new SendGridAPIClient(_apiKey);

            Email emailfrom = new Email(from);
            Email emailTo = new Email(to);
            Content content = new Content("text/plain", message);
            Mail mail = new Mail(emailfrom, subject, emailTo, content);

            dynamic response = await sg.client.mail.send.post(requestBody: mail.Get());
        }
    }
}
