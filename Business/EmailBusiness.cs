using Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using Helpers;

namespace Business
{
    public class EmailBusiness
    {
        private SendGridHelper _helper;

        public async Task Send(MailMessage message)
        {
            _helper = new SendGridHelper();
            foreach (var recipient in message.Recipients)
            {
                await _helper.Send("adilson@fazsite.com.br", recipient.Email, message.Name, message.Content);
            }
        }
    }
}
