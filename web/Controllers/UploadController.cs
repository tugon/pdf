using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class UploadController : Controller
    {
        // GET: Upload
        public ActionResult Index()
        {
            return PartialView();
        }

        public ActionResult Exemplo1()
        {
            return PartialView();
        }

        public ActionResult Exemplo2()
        {
            return PartialView();
        }
    }
}