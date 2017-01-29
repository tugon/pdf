using Business;
using Entities;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Web.Hosting;
using System.Web.Http;

namespace Web.Api
{
    [RoutePrefix("api/SendGrid")]
    public class SendGridController : BaseController
    {
        private readonly EmailBusiness _business;

        public SendGridController()
        {
            _business = new EmailBusiness();
        }

        [Route("Send")]
        [HttpPost]
        public async Task<IHttpActionResult> Send(MailMessage message)
        {
            HostingEnvironment.QueueBackgroundWorkItem(async cancellationToken =>
            {
                await _business.Send(message);
            });

            return Ok();
        }


    }
}
