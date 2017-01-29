using System.Threading.Tasks;
using System.Web.Http;

namespace Web.Api
{
    [RoutePrefix("api/upload")]
    public class UploadController : BaseController
    {

        [Route("UploadDocument")]
        [HttpPost]
        public async Task<IHttpActionResult> UploadDocument()
        {
            _path = "~/Documents";
            await UploadAndSave();

            return Ok();
        }
    }
}
