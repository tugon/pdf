using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web.Http;
using Helpers;
using Business;
using System.IO;

namespace Web.Api
{
    [RoutePrefix("api/pdf")]
    public class pdfController : ApiController
    {
        private ParentBusiness _helper;

        public pdfController()
        {
            _helper = new ParentBusiness();
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("generatePdf")]
        public HttpResponseMessage generatePdf()
        {
            var cssText = File.ReadAllText(System.Web.Hosting.HostingEnvironment.MapPath("~/content/template.css"));
            var html = File.ReadAllText(System.Web.Hosting.HostingEnvironment.MapPath("~/pdf/template.html"));
            var pdf = _helper.GeneratePdf(html,cssText);
            return GetContent(pdf, "pdf.pdf", "application/pdf");
        }

        private HttpResponseMessage GetContent(byte[] pdfBiteArray, string name, string contentType = null)
        {
            HttpResponseMessage result = null;

            try
            {

                result = Request.CreateResponse();
                result.Content = new StreamContent(pdfBiteArray.ToStream());
                if (contentType != null)
                    result.Content.Headers.ContentType = new MediaTypeHeaderValue(contentType);
                result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment");
                result.Content.Headers.ContentDisposition.FileName = name;
                result.StatusCode = HttpStatusCode.OK;
            }
            catch (Exception e)
            {
                result = Request.CreateResponse(HttpStatusCode.BadRequest, string.Concat(e.Message, e.InnerException != null ? e.InnerException.Message : ""));
            }

            return result;
        }
    }


}
