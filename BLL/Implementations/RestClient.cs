using System.Net.Http;
using System.Threading.Tasks;
using BLL.Interfaces;
using Flurl.Http;

namespace BLL.Implementations
{
    public class RestClient : IRestClient
    {
        public async Task<T> Get<T>(string url)
        {
            return await url.GetJsonAsync<T>();
        }

        public async Task<T> Post<T>(string url, string body)
        {
            var response = await url.PostUrlEncodedAsync(new StringContent(body));
            return await response.GetJsonAsync<T>();
        }
    }
}
