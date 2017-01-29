using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using Newtonsoft.Json;
using Helpers;
using Web.Api.Helpers;

namespace Web.Api
{
    public class BaseController : ApiController
    {
        protected IUploadManager _uploaManager;
        protected string _path;
        protected List<string> _uploadedFileList;

        [Route("getfile")]
        public HttpResponseMessage GetContent(string content, string name, string contentType = null, Encoding encoding = null)
        {
            HttpResponseMessage result = null;

            try
            {
                if (encoding == null)
                    encoding = Encoding.UTF8;
                // Serve the file to the client
                result = Request.CreateResponse(HttpStatusCode.OK);
                result.Content = new StreamContent(content.ToStream(encoding));
                if (contentType != null)
                    result.Content.Headers.ContentType = new MediaTypeHeaderValue(contentType);
                result.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment");
                result.Content.Headers.ContentDisposition.FileName = name;
            }
            catch (Exception e)
            {
                result = Request.CreateResponse(HttpStatusCode.BadRequest, string.Concat(e.Message, e.InnerException != null ? e.InnerException.Message : ""));
            }

            return result;
        }

        [Route("getfile")]
        public HttpResponseMessage GetFile(string path)
        {
            HttpResponseMessage result = null;
            var localFilePath = path;

            if (!File.Exists(localFilePath))
            {
                result = Request.CreateResponse(HttpStatusCode.Gone);
            }
            else
            {
                var info = new FileInfo(localFilePath);
                // Serve the file to the client
                result = Request.CreateResponse(HttpStatusCode.OK);
                result.Content.Headers.ContentType.CharSet = "iso-8859-1";
                result.Content = new StreamContent(new FileStream(localFilePath, FileMode.Open, FileAccess.Read));
                result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment");
                result.Content.Headers.ContentDisposition.FileName = info.Name;
            }

            return result;
        }

        protected async Task<HttpResponseMessage> UploadAndSave()
        {
            try
            {
                if (!Request.Content.IsMimeMultipartContent())
                {
                    this.Request.CreateResponse(HttpStatusCode.UnsupportedMediaType);
                }

                var provider = GetMultipartProvider();
                var result = await Request.Content.ReadAsMultipartAsync(provider);
                _uploadedFileList = new List<String>();

                foreach (var data in result.FileData)
                {
                    var originalFileName = GetDeserializedFileName(data);
                    
                    var uploadedFileInfo = new FileInfo(originalFileName);
                    
                    _uploadedFileList.Add(originalFileName);
                }
                return this.Request.CreateResponse(HttpStatusCode.OK, new { _uploadedFileList });
            }
            catch (Exception e)
            {
                return this.Request.CreateResponse(HttpStatusCode.BadRequest, new { e.Message });
            }
        }

        private string GetDeserializedFileName(MultipartFileData fileData)
        {
            var fileName = GetFileName(fileData);
            return JsonConvert.DeserializeObject(fileName).ToString();
        }

        private string GetFileName(MultipartFileData fileData)
        {
            return fileData.Headers.ContentDisposition.FileName;
        }

        private MultipartFormDataStreamProvider GetMultipartProvider()
        {

            var root = HttpContext.Current.Server.MapPath(_path);
            Directory.CreateDirectory(root);
            return new MyStreamProvider(root);
        }

        [HttpPost, Route("api/upload")]
        public async Task<HttpResponseMessage> Upload()
        {
            try
            {
                if (_uploaManager != null)
                {
                    var list = await _uploaManager.GetStreamReaderListAsync(this.Request);
                    return this.Request.CreateResponse(HttpStatusCode.OK, new { list });
                }
                return this.Request.CreateResponse(HttpStatusCode.BadRequest, "failure to upload");
            }
            catch (Exception e)
            {
                return this.Request.CreateResponse(HttpStatusCode.BadRequest, new { e.Message });
            }
        }

    }

    public class MyStreamProvider : MultipartFormDataStreamProvider
    {
        public MyStreamProvider(string uploadPath)
            : base(uploadPath)
        {

        }

        public override string GetLocalFileName(HttpContentHeaders headers)
        {
            string fileName = headers.ContentDisposition.FileName;
            if (string.IsNullOrWhiteSpace(fileName))
            {
                fileName = Guid.NewGuid().ToString() + ".data";
            }
            return fileName.Replace("\"", string.Empty);
        }
    }
}




