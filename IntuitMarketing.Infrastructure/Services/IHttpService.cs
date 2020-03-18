using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace IntuitMarketing.Infrastructure.Services
{
    public interface IHttpService
    {
        Task<bool> SendRequest(string uri, string dataToSend, string contentTypeHeaderValue);
    }
}
