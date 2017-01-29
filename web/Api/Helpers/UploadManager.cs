using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Web.Api.Helpers
{
    public class UploadManager : IUploadManager
    {
        public async Task<List<StreamReader>> GetStreamReaderListAsync(HttpRequestMessage request)
        {
            if (!request.Content.IsMimeMultipartContent())
            {
                request.CreateResponse(HttpStatusCode.UnsupportedMediaType);
            }

            var result = await request.Content.ReadAsMultipartAsync();
            var list = new List<StreamReader>();
            foreach (var data in result.Contents)
            {
                list.Add(await GetStreamReaderAsync(data));

            }
            return list;
        }

        public async Task<StreamReader> GetStreamReaderAsync(HttpContent data)
        {
            var result = await data.ReadAsStreamAsync();
            return new StreamReader(result);
        }

        public async Task<List<Stream>> GetStreamListAsync(HttpRequestMessage request)
        {
            if (!request.Content.IsMimeMultipartContent())
            {
                request.CreateResponse(HttpStatusCode.UnsupportedMediaType);
            }

            var result = await request.Content.ReadAsMultipartAsync();
            var list = new List<Stream>();
            foreach (var data in result.Contents)
            {
                list.Add(await GetStreamAsync(data));

            }
            return list;
        }

        public async Task<Stream> GetStreamAsync(HttpContent data)
        {
            var result = await data.ReadAsStreamAsync();
            return result;
        }
    }
}