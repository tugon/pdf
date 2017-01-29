using System.Web.Mvc;

namespace Web.Controllers
{
    public class EmailController : Controller
    {
        // GET: Email
        public ActionResult Index()
        {
            return PartialView();
        }
    }
}