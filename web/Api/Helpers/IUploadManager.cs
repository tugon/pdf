using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace Web.Api.Helpers
{
    public interface IUploadManager
    {
        Task<Stream> GetStreamAsync(HttpContent data);
        Task<List<Stream>> GetStreamListAsync(HttpRequestMessage request);
        Task<StreamReader> GetStreamReaderAsync(HttpContent data);
        Task<List<StreamReader>> GetStreamReaderListAsync(HttpRequestMessage request);
    }
}